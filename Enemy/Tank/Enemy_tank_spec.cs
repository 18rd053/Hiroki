using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_tank_spec : MonoBehaviour
{
    /// <summary>
    /// 敵戦車のスペック情報を持ち渡す
    /// </summary>

    private float Bullet_reload_time = 3f;
    private int Bullet_attack_point = 10;
    private float Lerp_value = 0.5f;
    private int Hp = 100;

    [SerializeField]
    private Enemy_tank_shot _Enemy_tank_shot;

    [SerializeField]
    private Enemy_tank_move _Enemy_tank_move;

    [SerializeField]
    private Enemy_tank_HP _Enemy_tank_HP;

    //動いてもいいかを受け取る
    private Game_master _Game_master;

    void Awake()
    {
        _Game_master = GameObject.FindWithTag("GM").GetComponent<Game_master>();

        _Enemy_tank_shot.Set_shot(Bullet_reload_time, Bullet_attack_point);
        _Enemy_tank_move.Set_Lerp_value(Lerp_value);
        _Enemy_tank_HP.Set_Hp(Hp);
    }

    //動かしていいか
    private void FixedUpdate()
    {
        if (_Game_master.Enemy_move_flg)
        {
            _Enemy_tank_move.enabled = true;
            _Enemy_tank_shot.enabled = true;
        }
        else
        {
            _Enemy_tank_move.enabled = false;
            _Enemy_tank_shot.enabled = false;
        }

        //HPクラスがなくなっていたら破壊されているのでゲームマスターに通知
        if (_Enemy_tank_HP == null) _Game_master.Kill_enemy();
    }

}
