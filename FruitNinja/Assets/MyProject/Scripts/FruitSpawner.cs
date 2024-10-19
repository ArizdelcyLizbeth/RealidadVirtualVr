using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    // Prefabs de frutas que se pueden generar (incluir la bomba en este array)
    public GameObject[] fruits;

    // Prefab de la bomba
    public GameObject bombPrefab;

    // Punto donde se generarán las frutas y la bomba (el Huacal)
    public Transform spawnPoint;

    // Número de frutas a generar (excluyendo la bomba)
    public int numberOfFruits = 5;

    // Altura donde las frutas y la bomba desaparecerán
    public float destroyHeight = -2.0f;

    // Velocidad mínima y máxima para que las frutas salgan del huacal
    public float minLaunchForce = 10.0f;  // Fuerza mínima de lanzamiento para frutas normales
    public float maxLaunchForce = 15.0f;  // Fuerza máxima de lanzamiento para frutas normales

    // Fuerza específica para la piña (más baja para que salga más lento)
    public float pineappleLaunchForce = 5.0f;

    // Fuerza de lanzamiento para la bomba
    public float bombLaunchForce = 12.0f;

    // Tiempo mínimo y máximo entre la aparición de cada fruta
    public float minSpawnDelay = 0.5f;
    public float maxSpawnDelay = 2.0f;

    // Lista para rastrear las frutas generadas
    private List<GameObject> activeFruits = new List<GameObject>();

    // Controlar una sola bomba activa a la vez
    private GameObject activeBomb = null;

    void Start()
    {
        // Iniciar la rutina que generará frutas y bombas
        StartCoroutine(SpawnFruits());
    }

    void Update()
    {
        // Chequear si alguna fruta ha caído por debajo de la altura de destrucción
        for (int i = activeFruits.Count - 1; i >= 0; i--)
        {
            if (activeFruits[i] != null && activeFruits[i].transform.position.y < destroyHeight)
            {
                Destroy(activeFruits[i]);
                activeFruits.RemoveAt(i);
            }
        }

        // Chequear si la bomba ha caído por debajo de la altura de destrucción
        if (activeBomb != null && activeBomb.transform.position.y < destroyHeight)
        {
            Destroy(activeBomb);
            activeBomb = null;
        }
    }

    IEnumerator SpawnFruits()
    {
        while (true)
        {
            if (activeFruits.Count < numberOfFruits)
            {
                // Esperar un tiempo aleatorio entre frutas
                yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
                SpawnFruit();
            }

            // Generar la bomba si no hay una activa
            if (activeBomb == null)
            {
                yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
                SpawnBomb();
            }
            else
            {
                yield return null; // Esperar al siguiente frame
            }
        }
    }

    void SpawnFruit()
    {
        // Seleccionar una fruta aleatoria
        GameObject fruit = fruits[Random.Range(0, fruits.Length)];

        // Desplazamiento aleatorio para la posición de generación
        Vector3 randomOffset = new Vector3(Random.Range(-0.5f, 0.5f), 0, Random.Range(-0.5f, 0.5f));

        // Generar la fruta desde la posición exacta del huacal
        Vector3 spawnPosition = spawnPoint.position + randomOffset;

        // Instanciar la fruta
        GameObject spawnedFruit = Instantiate(fruit, spawnPosition, Quaternion.identity);

        // Añadir la fruta generada a la lista de frutas activas
        activeFruits.Add(spawnedFruit);

        // Añadir una fuerza hacia arriba para que la fruta salga del huacal
        Rigidbody rb = spawnedFruit.GetComponent<Rigidbody>();
        if (rb != null)
        {
            if (spawnedFruit.name.Contains("Pineapple"))
            {
                // Usar menos fuerza para la piña
                rb.AddForce(Vector3.up * pineappleLaunchForce, ForceMode.Impulse);

                // Aplicar torque reducido a la piña
                float reducedTorque = pineappleLaunchForce * 0.03f; // Torque muy bajo para menos rotación
                rb.AddTorque(Random.insideUnitSphere * reducedTorque, ForceMode.Impulse);
            }
            else
            {
                // Lanzar otras frutas con fuerza aleatoria normal
                float launchForce = Random.Range(minLaunchForce, maxLaunchForce);
                rb.AddForce(Vector3.up * launchForce, ForceMode.Impulse);

                // Aplicar rotación aleatoria a otras frutas
                rb.AddTorque(Random.insideUnitSphere * launchForce, ForceMode.Impulse);
            }
        }
    }

    void SpawnBomb()
    {
        // Generar la bomba desde la posición exacta del huacal
        Vector3 spawnPosition = spawnPoint.position;

        // Instanciar la bomba
        activeBomb = Instantiate(bombPrefab, spawnPosition, Quaternion.identity);

        // Añadir una fuerza hacia arriba para que la bomba salga del huacal
        Rigidbody rb = activeBomb.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(Vector3.up * bombLaunchForce, ForceMode.Impulse);

            // Aplicar una rotación aleatoria a la bomba
            rb.AddTorque(Random.insideUnitSphere * bombLaunchForce, ForceMode.Impulse);
        }
    }
}

