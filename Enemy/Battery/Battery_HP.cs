using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery_HP : MonoBehaviour
{
    //各砲台の体力を管理

    private int Battery_Hp;

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
        if (Battery_Hp - Attack_point < 0) Battery_Hp = 0;
        else Battery_Hp -= Attack_point;

        Instantiate(Hit_canvas);

        if (Battery_Hp <= 0) Destruction();
    }

    public void Set_Hp(int Hp)
    {
        Battery_Hp = Hp;
    }

   private void Destruction()
    {
        Instantiate(Exp, transform.position, Quaternion.identity);

        Instantiate(Kill_canvas);
        _Game_master.Kill_enemy();

        Destroy(gameObject.transform.root.gameObject);
    }
}
