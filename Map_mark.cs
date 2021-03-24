using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_mark : MonoBehaviour
{
    private Camera Map_camera;

    // Start is called before the first frame update
    void Start()
    {
        Map_camera = GameObject.FindWithTag("Map_cam").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 r = Map_camera.transform.position;
        r.y = transform.position.y;
        transform.LookAt(r);
    }
}
