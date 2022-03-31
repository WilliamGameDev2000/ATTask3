using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    public AnimationCurve myCurve;

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);
    }
}
