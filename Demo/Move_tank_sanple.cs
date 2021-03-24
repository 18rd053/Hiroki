using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_tank_sanple : MonoBehaviour
{
    //戦車本体に取り付けるスクリプト 、移動回転など全般の制御
    Rigidbody Tank_rb;
    public float Tank_Speed;
    private float Tank_downforce = 3000;

    Vector3 Tank_Rote = new Vector3(0, -1f, 0);
    public float Speed_limit = 30f;

    [SerializeField]
    private GameObject SPattack_controller;

    private bool _SPflg = false;

    [SerializeField]
    private Camera SPcamera;

    private Animator SPanimator;

    public int SPpoint = 0;

    void Start()
    {
        SPcamera.enabled = false;
        Tank_rb = GetComponent<Rigidbody>();
        Tank_Speed = 2000f;

        SPanimator = SPcamera.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //常に下に力を働かせておく。
        Tank_rb.AddForce(-transform.up * Tank_downforce * 0.5f);

        //加速制限
        if (Tank_rb.velocity.magnitude < Speed_limit)
        {
            //必殺技の演出中は移動不可
            if (!_SPflg)
            {
                if (Input.GetKey(KeyCode.W)) Tank_rb.AddForce(transform.forward * Tank_Speed);
                else if (Input.GetKey(KeyCode.A)) Tank_rb.angularVelocity = Tank_Rote;
                else if (Input.GetKey(KeyCode.D)) Tank_rb.angularVelocity = -Tank_Rote;
                if (Input.GetKey(KeyCode.S)) Tank_rb.AddForce(-transform.forward * Tank_Speed);

            }
            if (Input.GetKeyDown(KeyCode.Space)) SPattack();
            //Instantiate(SPattack_controller,transform.position,transform.rotation);

        }
        //Force_Zero();
    }

    void Force_Zero()
    {
        Tank_rb.angularVelocity = Vector3.zero;
        Tank_rb.velocity = Vector3.zero;
    }

    /*
    private void OnCollisionEnter(Collision Bullet)
    {
        if(Bullet.gameObject.tag == "Bullet")
        {
            Debug.Log("hidan");
        }
    }
    */

    private void SPattack()
    {
        if (SPpoint >= 1)
        {
            SPpoint -= 1;
            //SPattack中、演出情報を受け取り、操作不可能時間を設定
            SPanimator.SetTrigger("SPattack");

            SPflg_true();
            SPattack_controller.SetActive(true);

            SPattack _script = GetComponent<SPattack>();
            float Spattack_time = _script._SPattack();

            Invoke("SPflg_false", Spattack_time);

        }
    }
    public void SPflg_true()
    {
        SPcamera.enabled = true;
        _SPflg = true;
    }


    public void SPflg_false()
    {
        _SPflg = false;
        SPcamera.enabled = false;
        SPattack_controller.SetActive(false);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SPball")
        {
            SPpoint += 1;
            Destroy(collision.gameObject);
        }
    }
}
