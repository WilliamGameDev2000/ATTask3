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

        //StartCoroutine("CheckChunkDistance");
    }

    private void FixedUpdate()
    {
        List<Chunks> removeList = new List<Chunks>();

        if (chunks.Count > 0)
        {
            foreach (Chunks chunk in chunks)
            {
                if (Vector3.Distance(player.transform.position, chunk.chunkPos) < distanceFromPlayer || Vector3.Distance(player.transform.position, chunk.chunkPos + chunkBB) < distanceFromPlayer)
                {
                    if (chunk.chunk == null)
                    {
                        removeList.Add(chunk);
                    }
                    else
                    {
                        chunk.chunk.loadChunk();
                        if (chunk.entities != null)
                            chunk.entities.LoadEntities();
                    }
                }
                else
                {
                    if (chunk.chunk == null)
                    {
                        removeList.Add(chunk);
                    }
                    else
                    {
                        chunk.chunk.unloadChunk();
                        if (chunk.entities != null)
                            chunk.entities.UnloadEntities();
                    }
                }
            }
        }

        if (removeList.Count > 0)
        {
            foreach (Chunks chunk in removeList)
            {
                chunks.Remove(chunk);
            }
        }

    }

    IEnumerator CheckChunkDistance()
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
                        if (chunk.entities != null)
                            chunk.entities.LoadEntities();
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
                        if (chunk.entities != null)
                            chunk.entities.UnloadEntities();
                    }
                }
            }
        }

        yield return new WaitForSeconds(0.02f);

        if(removeList.Count > 0)
        {
            foreach(Chunks chunk in removeList)
            {
                chunks.Remove(chunk);
            }
        }

        yield return new WaitForSeconds(0.02f);
        StartCoroutine("CheckChunkDistance");
    }
}

public struct Chunks
{
    public LoadChunk chunk;
    public Vector3 chunkPos;
    public EntityList entities;
    //public Vector3 entityPos;
}
