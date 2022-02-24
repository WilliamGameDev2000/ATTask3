using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LoadChunk : MonoBehaviour
{
    private Vector3 playerPos;

    int terrainDivision = 16;

    GameObject empty;

    [SerializeField] List<TerrainData> ChunkDat;
    [SerializeField] List<GameObject> ChunkObj;

    private void Start()
    {
        empty = new GameObject();
        playerPos = GameObject.Find("Player").transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            for (int i = 0; i < 4; i++)
            {
                loadChunk(i);   
            }
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            for (int i = ChunkObj.Count-1; i >= 0; i--)
            {
                deloadChunk(i);
            }
        }
    }

    void loadChunk(int index)
    {
        var _data = Resources.Load<TerrainData>("Terrain/" + ChunkDat[index].name);
        var _obj = Terrain.CreateTerrainGameObject(_data);

        var parent = Instantiate(empty);
        
        _obj.transform.parent = parent.transform;
        parent.transform.position = new Vector3(0, 0, index * 140.625f);
        ChunkObj.Add(_obj);
    }

    void deloadChunk(int index)
    {
        
        Destroy(ChunkObj[index]);
        ChunkObj.Remove(ChunkObj[index]);
        Resources.UnloadUnusedAssets();
    }
}
