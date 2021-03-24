using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_camera : MonoBehaviour
{
    private Vector3 str_pos;
    private Quaternion str_rota;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartAnimation()
    {
        Debug.Log("start");
        str_pos = transform.position;
        str_rota = transform.rotation;
        Debug.Log(str_pos);
        //Debug.Log(str_rota);
        Debug.Log("------");
    }

    void EndAnimation()
    {
        Debug.Log("end");
        transform.position = str_pos;
        transform.rotation = str_rota;
        Debug.Log(str_pos);
        //Debug.Log(str_rota);
    }
}
