using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Camera_Dest : MonoBehaviour
{

    private float Animation_time = 1.2f;

    [SerializeField]
    private GameObject Tank;


    // Start is called before the first frame update
    void Start()
    {
        Move_tank_sanple Tank_script = GetComponent<Move_tank_sanple>();
        Tank_script.SPflg_true();
        //Destroy(this.gameObject, Animation_time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float Animation_timer()
    {
        return Animation_time;
    }
    public void OnEnable()
    {
       
    }

    public void OnDisable()
    {
        
    }


}
