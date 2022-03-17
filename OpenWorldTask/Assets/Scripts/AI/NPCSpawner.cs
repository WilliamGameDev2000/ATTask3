using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject NPCPrefabs;
  
    void Start()
    {
        SpawnNPC();
    }



    void SpawnNPC()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Instantiate(NPCPrefabs, spawnPoints[i].position, Quaternion.identity);
        }
        
    }
}
