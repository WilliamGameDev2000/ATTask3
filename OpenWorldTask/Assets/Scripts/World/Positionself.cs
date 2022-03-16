using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Positionself : MonoBehaviour
{
    GameObject Self;
    void Start()
    {
        Self = GameObject.Find("TerrainOBJs");

        int x_pos = 0;
        int y_pos = 0;

        for (int i = 0; i < Self.transform.childCount; i++)
        {

            if (x_pos > 15)
            {
                x_pos = 0;
                y_pos++;
            }

            Self.transform.GetChild(i).position = new Vector3(y_pos * -140.625f, 0, x_pos * 140.625f);
            x_pos++;
        }
    }

}
