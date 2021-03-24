using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panzer_VI_E : MonoBehaviour
{ 
    /// <summary>
    /// Panzer_VI_E本体に取り付けるスクリプト
    /// タンクの情報を格納
    /// SPattackを管理
    /// </summary>

    ///Tank_moveに渡す情報
    public float Tank_speed = 500f;
    public float Speed_limit = 50f;
    Vector3 Tank_rote = new Vector3(0, -2f, 0);
    Rigidbody Tank_rb;


    /// Tank_shotに渡す情報
    [SerializeField]
    private GameObject Gun_pos;
    public float Bullet_reload_time = 4f;
    public int Bullet_attack_point = 20;


    /// Tank_HPに渡す情報
    public int Hp = 200;

    /// Tank_SPattackに渡す固有のSPattack時BGM
    [SerializeField]
    private AudioClip SPattack_BGM;


    public void Awake()
    {

        Tank_rb = GetComponent<Rigidbody>();

        //Tank_moveに機体性能をセット
        GetComponent<Tank_move>()
            .Set_move(Tank_rb, Tank_speed, Speed_limit, Tank_rote);

        GetComponent<Tank_move>()
            .Set_flg(true);

        //Tank_shotに射撃性能をセット
        Gun_pos.GetComponent<Tank_shot>()
            .Set_shot(Bullet_reload_time, Bullet_attack_point);

        //Tank_HPに最大HPをセット
        GetComponent<Tank_HP>()
            .Set_hp(Hp);

        //Tank_SPattackに専用BGMをセット
        GetComponent<Tank_SPattack>()
            .Set_SPattack_BGM(SPattack_BGM);
    }

}

