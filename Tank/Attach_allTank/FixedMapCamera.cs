using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedMapCamera : MonoBehaviour
{

    void FixedUpdate()
    {
        transform.localRotation = Quaternion.Euler(90, 0, 0);
        //transform.localPosition = new Vector3(1000 , 500, 1000);
    }
}
