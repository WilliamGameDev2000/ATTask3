using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityList : MonoBehaviour
{
    //add this to every chunk and have them add to it all the objects it can find in the boarders?(require type of kinda deal)
    [SerializeField] List<GameObject> chunk_object_entities = new List<GameObject>();
    [SerializeField] List<GameObject> chunk_NPC_entities = new List<GameObject>();

    public void LoadEntities()
    {
        if (chunk_object_entities.Count > 0)
        {
            foreach (GameObject o in chunk_object_entities)
            {
                o.SetActive(true);
            }
        }

        if(chunk_NPC_entities.Count > 0)
        {
            foreach (GameObject o in chunk_NPC_entities)
            {
                o.SetActive(true);
            }
        }
    }

    public void UnloadEntities()
    {
        if (chunk_object_entities.Count > 0)
        {
            foreach (GameObject o in chunk_object_entities)
            {
                o.SetActive(false);
            }
        }

        if (chunk_NPC_entities.Count > 0)
        {
            foreach (GameObject o in chunk_NPC_entities)
            {
                if(o.transform.childCount > 0)
                {
                    Destroy(o.transform.GetChild(0).gameObject);
                }
                    
                o.SetActive(false);
            }
        }
    }
}
