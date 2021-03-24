using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cromwell_IV_SP : MonoBehaviour
{
    //SPattackを発動していいか監視
    [SerializeField]
    private Tank_SPattack _Tank_SPattack;

    /// <summary>
    /// CromwellのSPattackは30秒間リロード時間短縮
    /// </summary>


    /// Tank_shotに渡す情報
    [SerializeField]
    private Tank_shot _Tank_shot;
    public float Bullet_reload_time = 3f;
    public float Sp_bullet_reload_time = 1f;
    public int Bullet_attack_point = 10;

    //効果時間
    private float SP_time = 30f;


    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        if (_Tank_SPattack.Check_SPattack())
        {
            SPattack_active();
        }
    }

    public void SPattack_active()
    {
        _Tank_shot.Set_shot(Sp_bullet_reload_time, Bullet_attack_point);
        Invoke("SPattack_end", SP_time);
    }

    //SPattack終了
    public void SPattack_end()
    {
        _Tank_shot.Set_shot(Bullet_reload_time, Bullet_attack_point);

        //演出をoffに
        _Tank_SPattack.SPattack_end();
    }
}
