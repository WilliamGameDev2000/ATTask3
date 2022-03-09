using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChunk : MonoBehaviour
{
    private Vector2 oldPos = new Vector2(999999, 999999);
    Vector3 playerPos;

    float spawnDist = 150;
    float loadDist = 300;

    private void Start()
    {
        playerPos = this.transform.position;
    }

    private void Update()
    {
        int posX = Mathf.RoundToInt(playerPos.x / loadDist), posZ = Mathf.RoundToInt(playerPos.z / loadDist);
        if(new Vector2(posX, posZ) != oldPos)
        {
            oldPos = new Vector2(posX, posZ);

            if (Vector2.Distance(oldPos, playerPos) <= spawnDist)
            {
                //load
            }
        }
    }
}
