using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

public class ForceSpawn : MonoBehaviour
{
    [Header("ForceSpawn Settings")]
    [SerializeField] private GameObject SP1;
    [SerializeField] private GameObject SP2;
    [SerializeField] private GameObject SP3;
    [SerializeField] private GameObject SP4;
    [SerializeField] private GameObject SP5;
    [SerializeField] private GameObject SP6;
    [SerializeField] private GameObject SP7;
    [SerializeField] private GameObject SP8;
    
    
    
    private GameTimer Timer;
    private GameObject[] SpawnerArray;
    private int[] ForceSeed = new int[20];
    private int[] SpawnerDecision = new int[20];
    private int ForceSpawnCounter;
    private int PreventOvershoot;
    private bool found;
    Spawn Spawnscript;
    // Start is called before the first frame update
    void Start()
    {
        Timer = FindFirstObjectByType<GameTimer>();
        ForceSpawnCounter = 0;
        SpawnerArray = new GameObject[8] {SP1, SP2, SP3, SP4, SP5, SP6, SP7, SP8};
        for (int x=0; x<20; x++)
        {
            ForceSeed[x] = Random.Range(((x*8)+1), ((x+1)*8));
            SpawnerDecision[x] = Random.Range(1,8);
        }
        Debug.Log(string.Join(", ", ForceSeed));
    }

    // Update is called once per frame
    void Update()
    {
        found = ForceSeed.Contains((int)Timer.elapsed);
        if (found == true)
        {
            if (!(PreventOvershoot == (int)Timer.elapsed))
            {
            Spawnscript = SpawnerArray[ForceSpawnCounter].GetComponent<Spawn>();
            Spawnscript.Probability = 0.0f;
            Spawnscript.SpawnNpc();
            Spawnscript.Probability = 0.7f;
            Debug.Log(SpawnerDecision[ForceSpawnCounter]);
            ForceSpawnCounter++;
            }
            PreventOvershoot = (int)Timer.elapsed;
        }
        print(ForceSpawnCounter);
    }
}
