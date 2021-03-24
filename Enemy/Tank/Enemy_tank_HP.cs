using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_tank_HP : MonoBehaviour
{
    //敵戦車の体力を管理

    private int Enemy_tank_Hp;

    //被弾時に表示
    [SerializeField]
    private Canvas Hit_canvas;
    //非破壊時に表示
    [SerializeField]
    private Canvas Kill_canvas;

    //破壊された時のエフェクト
    [SerializeField]
    private ParticleSystem Exp;

    //破壊されたことを通知
    private Game_master _Game_master;

    void Start()
    {
        _Game_master = GameObject.FindWithTag("GM").GetComponent<Game_master>();
    }

    public void Damage(int Attack_point)
    {
        if (Enemy_tank_Hp - Attack_point < 0) Enemy_tank_Hp = 0;
        else Enemy_tank_Hp -= Attack_point;


        Instantiate(Hit_canvas);

        if (Enemy_tank_Hp <= 0) Destruction();
    }

    public void Set_Hp(int Hp)
    {
        Enemy_tank_Hp = Hp;
    }

    private void Destruction()
    {
        Instantiate(Kill_canvas);

        Instantiate(Exp, transform.position, Quaternion.identity);
        _Game_master.Kill_enemy();

        Destroy(gameObject.transform.root.gameObject);
    }
}
