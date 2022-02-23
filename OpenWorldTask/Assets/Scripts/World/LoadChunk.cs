using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadChunk : MonoBehaviour
{
    private Vector3 playerPos;

    int terrainDivision = 16;

    [SerializeField] List<TerrainData> ChunkDat;
    [SerializeField] List<GameObject> ChunkObj;

    private void Start()
    {
        playerPos = GameObject.Find("Player").transform.position;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            for (int i = 0; i < 10; i++)
            {
                loadChunk(i);
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            for (int i = 0; i < 10; i++)
            {
                deloadChunk(i);
            }
        }
    }

    void loadChunk(int index)
    {
        var _data = Resources.Load<TerrainData>("Terrain/" + ChunkDat[index].name);

        ChunkObj.Add(Terrain.CreateTerrainGameObject(_data));
    }

    void deloadChunk(int index)
    {
        
        Destroy(ChunkObj[index]);
        ChunkObj.Remove(ChunkObj[index]);
        Resources.UnloadUnusedAssets();
    }
}
