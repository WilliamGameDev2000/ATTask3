using System.Collections.Generic;
using UnityEngine;

public class PseudoInventory : MonoBehaviour
{
    List<GameObject> Items;
    

    void Start()
    {
        Items = new List<GameObject>();
    }

    public void AddToInventory(GameObject pick_up)
    {
        Items.Add(pick_up);
    }

    public bool CheckInventory(GameObject check)
    {
        if(Items.Count > 0)
        {
            Debug.Log("Item in inventory");
            return Items.Contains(check);
        }
        return false;
    }
}
