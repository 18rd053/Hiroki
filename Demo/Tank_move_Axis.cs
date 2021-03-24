using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_move_Axis : MonoBehaviour
{

    private Rigidbody rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        rb.AddForce(y * transform.forward * speed);
        rb.angularVelocity = new Vector3(0 , x, 0);
    }
}
