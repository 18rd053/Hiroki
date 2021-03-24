using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryM_spec : MonoBehaviour
{
    /// <summary>
    /// 敵砲台M（中間）のスペック情報を持ち渡す
    /// </summary>
    private float Bullet_reload_time = 5f;
    private int Bullet_attack_point = 5;
    private int Bullet_size = 3;
    private float Lerp_value = 0.5f;
    private int Hp = 30;
    /// 

    [SerializeField]
    private Battery_shot _Battery_shot;

    [SerializeField]
    private Search_player _Search_player;

    [SerializeField]
    private Battery_HP _Battery_HP;

    //動いてもいいかを受け取る
    private Game_master _Game_master;

    void Start()
    {
        _Game_master = GameObject.FindWithTag("GM").GetComponent<Game_master>();

        _Battery_shot.Set_shot(Bullet_reload_time, Bullet_attack_point, Bullet_size);
        _Search_player.Set_lerp_value(Lerp_value);
        _Battery_HP.Set_Hp(Hp);
    }

    //動かしていいか
    private void FixedUpdate()
    {
        if (_Game_master.Enemy_move_flg)
        {
            _Battery_shot.enabled = true;
            _Search_player.enabled = true;
        }
        else
        {
            _Battery_shot.enabled = false;
            _Search_player.enabled = false;
        }
    }
}
