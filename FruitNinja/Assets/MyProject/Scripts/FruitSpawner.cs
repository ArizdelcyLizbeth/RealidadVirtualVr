using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esta clase se encarga de generar frutas y bombas en posiciones aleatorias,
/// lanzandolas hacia arriba con fuerzas variables y eliminandolas si caen por debajo de una altura especifica.
/// </summary>
public class FruitSpawner : MonoBehaviour
{
    public GameObject[] fruits;
    public GameObject bombPrefab;
    public Transform spawnPoint;
    public float destroyHeight = -2.0f;
    public float minLaunchForce = 10.0f;
    public float maxLaunchForce = 15.0f;
    public float pineappleLaunchForce = 5.0f;
    public float bombLaunchForce = 12.0f;
    public float minSpawnDelay = 0.5f;
    public float maxSpawnDelay = 2.0f;

    private List<GameObject> activeFruits = new List<GameObject>();
    private GameObject activeBomb = null;
    private SpriteManager spriteManager;

    /// <summary>
    /// El metodo Start se llama al inicio del juego. Aqui se inicializa el SpriteManager y se comienza
    /// la rutina de generacion de frutas y bombas.
    /// </summary>
    void Start()
    {
        spriteManager = GameObject.Find("Panel").GetComponent<SpriteManager>();
        StartCoroutine(SpawnFruits());
    }

    /// <summary>
    /// En cada frame, este metodo revisa si hay frutas o bombas que han caido por debajo de la altura limite,
    /// y las destruye si es necesario.
    /// </summary>
    void Update()
    {
        for (int i = activeFruits.Count - 1; i >= 0; i--)
        {
            if (activeFruits[i] != null && activeFruits[i].transform.position.y < destroyHeight)
            {
                Destroy(activeFruits[i]);
                activeFruits.RemoveAt(i);
            }
        }

        if (activeBomb != null && activeBomb.transform.position.y < destroyHeight)
        {
            Destroy(activeBomb);
            activeBomb = null;
        }
    }

    /// <summary>
    /// Coroutine que controla la generacion periodica de frutas y bombas.
    /// Se detiene cuando el juego ha terminado.
    /// </summary>
    IEnumerator SpawnFruits()
    {
        while (true)
        {
            if (spriteManager != null && spriteManager.IsGameOver())
            {
                yield break; 
            }

            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnFruit();

            if (activeBomb == null && !(spriteManager != null && spriteManager.IsGameOver()))
            {
                yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
                SpawnBomb();
            }
            else
            {
                yield return null; 
            }
        }
    }

    /// <summary>
    /// Genera una fruta aleatoria de la lista y la lanza desde el punto de generacion.
    /// </summary>
    void SpawnFruit()
    {
        GameObject fruit = fruits[Random.Range(0, fruits.Length)];
        Vector3 randomOffset = new Vector3(Random.Range(-0.5f, 0.5f), 0, Random.Range(-0.5f, 0.5f));
        Vector3 spawnPosition = spawnPoint.position + randomOffset;

        GameObject spawnedFruit = Instantiate(fruit, spawnPosition, Quaternion.identity);
        activeFruits.Add(spawnedFruit);

        Rigidbody rb = spawnedFruit.GetComponent<Rigidbody>();
        if (rb != null)
        {
            if (spawnedFruit.name.Contains("Pineapple"))
            {
                rb.AddForce(Vector3.up * pineappleLaunchForce, ForceMode.Impulse);
                float reducedTorque = pineappleLaunchForce * 0.03f;
                rb.AddTorque(Random.insideUnitSphere * reducedTorque, ForceMode.Impulse);
            }
            else
            {
                float launchForce = Random.Range(minLaunchForce, maxLaunchForce);
                rb.AddForce(Vector3.up * launchForce, ForceMode.Impulse);
                rb.AddTorque(Random.insideUnitSphere * launchForce, ForceMode.Impulse);
            }
        }
    }
    /// <summary>
    /// Genera una bomba y la lanza desde el punto de generacion.
    /// Solo puede haber una bomba activa a la vez.
    /// </summary>
    void SpawnBomb()
    {
        Vector3 spawnPosition = spawnPoint.position;
        activeBomb = Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
        Rigidbody rb = activeBomb.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(Vector3.up * bombLaunchForce, ForceMode.Impulse);
            rb.AddTorque(Random.insideUnitSphere * bombLaunchForce, ForceMode.Impulse);
        }
    }
}
