using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkPool : MonoBehaviour
{
    public static ChunkPool sharedInstance;
    public List<ChunkObject> pooledChunks;
    public ChunkObject chunkToPool;
    public int chunkCount;

    private void Awake()
    {
        sharedInstance = this;
    }

    private void Start()
    {
        pooledChunks = new List<ChunkObject>();
        ChunkObject tmp;
        for (int i = 0; i < chunkCount; i++)
        {
            //tmp = 
            //pooledChunks.Add(tmp);
        }
    }
}
