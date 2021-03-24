using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panzer_VI_E_SP : MonoBehaviour
{
    //SPattackを発動していいか監視
    [SerializeField]
    private Tank_SPattack _Tank_SPattack;

    /// <summary>
    /// Panzer_VI_EのSPattackは5発分威力UPリロードDown
    /// </summary>


    /// Tank_shotに渡す情報
    [SerializeField]
    private Tank_shot _Tank_shot;
    public float Bullet_reload_time = 4f;
    public float Sp_bullet_reload_time = 5f;
    public int Bullet_attack_point = 20;
    public int Sp_bullet_attack_point = 30;

    //効果時間
    private int Capacity = 5;

    //初期弾数の0と必殺技終了の0を見分けるためのフラグ
    private bool SP_flg = false;
    void Start()
    {

    }


    void FixedUpdate()
    {
        if (_Tank_SPattack.Check_SPattack())
        {
            SP_flg = true;
            SPattack_active();
        }
        //残り強化弾数が0以下なら必殺技を終了
        if(_Tank_shot.Bullet_Capacity <= 0 && SP_flg)
        {
            SPattack_end();
        }
    }

    public void SPattack_active()
    {
        //５発分の強化弾をセット
        _Tank_shot.Set_Capacity(Capacity);
        _Tank_shot.Set_shot(Sp_bullet_reload_time, Sp_bullet_attack_point);
    }

    //SPattack終了
    public void SPattack_end()
    {
        _Tank_shot.Set_shot(Bullet_reload_time, Bullet_attack_point);

        SP_flg = false;

        //演出をoffに
        _Tank_SPattack.SPattack_end();
    }
}
