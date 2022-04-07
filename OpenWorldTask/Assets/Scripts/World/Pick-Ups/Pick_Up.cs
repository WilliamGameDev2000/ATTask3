using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerInstance.instance.Inventory.AddToInventory(transform.gameObject);
            gameObject.GetComponent<MeshFilter>().sharedMesh = null;
        }
    }
}
