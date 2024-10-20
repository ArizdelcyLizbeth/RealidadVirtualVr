using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject[] fruits;
    public GameObject bombPrefab;
    public Transform spawnPoint;
    public int numberOfFruits = 5;
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

    void Start()
    {
        // Buscar el SpriteManager
        spriteManager = GameObject.Find("Panel").GetComponent<SpriteManager>();
        StartCoroutine(SpawnFruits());
    }

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

    IEnumerator SpawnFruits()
    {
        while (true)
        {
            // Detener la generación si el juego ha terminado
            if (spriteManager != null && spriteManager.IsGameOver())
            {
                yield break; // Termina el coroutine
            }

            if (activeFruits.Count < numberOfFruits)
            {
                yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
                SpawnFruit();
            }

            // Generar la bomba si no hay una activa y el juego no ha terminado
            if (activeBomb == null && !(spriteManager != null && spriteManager.IsGameOver()))
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
