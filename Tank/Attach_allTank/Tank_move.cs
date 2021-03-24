using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_move : MonoBehaviour
{

    /// <summary>
    /// メインの戦車スクリプト に情報を渡されキーボードによる移動を管理
    /// </summary>
    private Rigidbody Tank_rb;
    private float Tank_speed;
    private float Speed_limit;
    private Vector3 Tank_rote;

    public float Tank_downforce = 100;

    private bool Move_flg = true;


    private Tank_move_sound TMSound;

    private bool TMSound_flg = true;

    ///タンク移動時のエフェクト表示
    [SerializeField]
    private Tank_move_EF _Tank_move_EF;

    void Start()
    {
        TMSound = GetComponent<Tank_move_sound>();
        Tank_rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    private void FixedUpdate()
    {

        //常に下に力を働かせておく。
        Tank_rb.AddForce(-transform.up * Tank_downforce * 100f);

        if (Tank_rb.velocity.magnitude < Speed_limit) {
            if (Move_flg)
            {
               
                if (TMSound_flg && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||
                    Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
                {

                    //移動開始時の音、エフェクト
                    _Tank_move_EF.Move_start_somoke(true);
                    TMSound.Smoke();
                    TMSound.Tank_move(TMSound_flg);
                    TMSound_flg = !TMSound_flg;
                }

                float x = Input.GetAxis("Horizontal");
                float y = Input.GetAxis("Vertical");
                var _foward = transform.forward;
                _foward.y = 0;

                Tank_rb.AddForce(y * transform.forward * Tank_speed);
                Tank_rb.angularVelocity = new Vector3(0, x, 0);

                
                
            }
        }

        

        if (!TMSound_flg && (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) ||
                    Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D)))
        {
            TMSound.Smoke();
            _Tank_move_EF.Move_start_somoke(true);

            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) &&
                    !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
            {
                //移動停止時の音、エフェクト
                TMSound.Smoke();
                _Tank_move_EF.Move_start_somoke(false);
                TMSound.Tank_move(TMSound_flg);
                TMSound_flg = !TMSound_flg;
            }

        }
    }

    public void Set_move(Rigidbody _Tank_rb ,float _Tank_speed,float _Speed_limit, Vector3 _Tank_rote)
    {

       Tank_rb = _Tank_rb;
       Tank_speed = _Tank_speed;
       Tank_rote = _Tank_rote;
        Speed_limit = _Speed_limit;
    }

    public void Set_flg(bool  boo)
    {
        Move_flg = boo;
    }
}