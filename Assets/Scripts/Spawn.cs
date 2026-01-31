using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject npcPrefabA;
    [SerializeField] private GameObject npcPrefabB;
    [SerializeField] private GameObject npcPrefabC;
    [SerializeField] private GameObject npcPrefabD;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float minSpawnTime = 1.5f;
    [SerializeField] private float maxSpawnTime = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);

            SpawnNpc();
        }
    }

    private void SpawnNpc()
    {
        if (spawnPoints.Length == 0) return;

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject npcToSpawn = GetNpcByProbability();

        Instantiate(npcToSpawn, spawnPoint.position, Quaternion.identity);
    }

    private GameObject GetNpcByProbability()
    {
        float roll = Random.value; // 0.0 - 1.0

        // 70% chance → A or B
        if (roll <= 0.7f)
        {
            return Random.value < 0.5f ? npcPrefabA : npcPrefabB;
        }
        // 30% chance → C or D
        else
        {
            return Random.value < 0.5f ? npcPrefabC : npcPrefabD;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
