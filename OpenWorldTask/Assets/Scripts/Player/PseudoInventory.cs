using System.Collections.Generic;
using UnityEngine;

public class PseudoInventory : MonoBehaviour
{
    [SerializeField]
    List<GameObject> Items = new List<GameObject>();
    [SerializeField]
    GameObject chunkContainer;
    

    public void AddToInventory(GameObject pick_up)
    {
        Items.Add(Instantiate(pick_up, this.transform));
        for(int i = 0; i < GameObject.Find("TerrainOBJs").transform.childCount; i++)
        {
            chunkContainer.transform.GetChild(i).GetComponent<EntityList>().Remove(pick_up);
        }
        Destroy(pick_up);
    }

    public bool CheckInventory(GameObject check)
    {
        if(Items.Count > 0)
        {
            //Debug.Log(Items.Contains(GameObject.FindGameObjectWithTag(check.tag)));
            return Items.Contains(GameObject.FindGameObjectWithTag(check.tag));
        }
        return false;
    }
}
