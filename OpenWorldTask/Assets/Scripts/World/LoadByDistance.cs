using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadByDistance : MonoBehaviour
{
    [SerializeField]
    private int distanceFromPlayer;

    private GameObject player;

    public List<Chunks> chunks;

    void Start()
    {
        player = GameObject.Find("Player");
        chunks = new List<Chunks>();

        StartCoroutine("CheckActivation");
    }

    IEnumerator CheckActivation()
    {
        List<Chunks> removeList = new List<Chunks>();

        if(chunks.Count > 0)
        {
            foreach(Chunks chunk in chunks)
            {
                if(Vector3.Distance(player.transform.position, chunk.chunkPos) > distanceFromPlayer)
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
                else
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
