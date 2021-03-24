using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis_sample_tankspec : MonoBehaviour
{
    /// <summary>
    /// クロムウェル本体に取り付けるスクリプト
    /// タンクの情報を格納
    /// SPattackを管理
    /// </summary>

    ///Tank_moveに渡す情報
    public float Tank_speed = 700f;
    public float Speed_limit = 60f;
    Vector3 Tank_rote = new Vector3(0, -2f, 0);
    Rigidbody Tank_rb;


    /// Tank_shotに渡す情報
    [SerializeField]
    private GameObject Gun_pos;
    public float Bullet_reload_time = 3f;
    public int Bullet_attack_point = 10;


    /// Tank_HPに渡す情報
    public int Hp = 100;



    public void Awake()
    {

        Tank_rb = GetComponent<Rigidbody>();

        //Tank_moveに機体性能をセット
        GetComponent<Tank_Axis_sample>()
            .Set_move(Tank_rb, Tank_speed, Speed_limit, Tank_rote);

        GetComponent<Tank_Axis_sample>()
            .Set_flg(true);

        //Tank_shotに射撃性能をセット
        Gun_pos.GetComponent<Tank_shot>()
            .Set_shot(Bullet_reload_time, Bullet_attack_point);

        //Tank_HPに最大HPをセット
        GetComponent<Tank_HP>()
            .Set_hp(Hp);
    }

}
