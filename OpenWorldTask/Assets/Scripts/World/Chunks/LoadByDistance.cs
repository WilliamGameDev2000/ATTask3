using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadByDistance : MonoBehaviour
{
    [SerializeField]
    private int distanceFromPlayer;
    private float chunkBBSize = -140.625f;
    private Vector3 chunkBB;

    private GameObject player;

    public List<Chunks> chunks;

    void Start()
    {
        player = GameObject.Find("Player");
        chunks = new List<Chunks>();

        chunkBB.x = chunkBBSize;
        chunkBB.z = -chunkBBSize;

        StartCoroutine("CheckActivation");
    }

    IEnumerator CheckActivation()
    {
        List<Chunks> removeList = new List<Chunks>();

        if(chunks.Count > 0)
        {
            foreach(Chunks chunk in chunks)
            {
                if(Vector3.Distance(player.transform.position, chunk.chunkPos) < distanceFromPlayer || Vector3.Distance(player.transform.position, chunk.chunkPos + chunkBB) < distanceFromPlayer)
                {
                    if(chunk.chunk == null)
                    {
                        removeList.Add(chunk);
                    }
                    else
                    {
                        chunk.chunk.loadChunk();
                    }
                }
                else
                {
                    if(chunk.chunk == null)
                    {
                        removeList.Add(chunk);
                    }
                    else
                    {
                        chunk.chunk.unloadChunk();
                        
                    }
                }
            }
        }

        yield return new WaitForSeconds(0.01f);

        if(removeList.Count > 0)
        {
            foreach(Chunks chunk in removeList)
            {
                chunks.Remove(chunk);
            }
        }

        yield return new WaitForSeconds(0.01f);
        StartCoroutine("CheckActivation");
    }
}

public class Chunks
{
    public LoadChunk chunk;
    public Vector3 chunkPos;
}
