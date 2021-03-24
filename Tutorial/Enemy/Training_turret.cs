using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training_turret : MonoBehaviour
{

    private float Timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Timer += Time.deltaTime;
        if (Timer >= 2)
        {
            Timer = 0;

            int a = Random.Range(1, 3);
            if (a == 1) transform.Rotate(0, 10f, 0);
            else if (a == 2) transform.Rotate(0, -10f, 0);
        }
    }

}
