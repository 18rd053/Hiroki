using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_enemy_tank : MonoBehaviour
{
    //敵タンクの弾自体に取り付けるスクリプト 、自壊とスピードを加える。
    Rigidbody Bullet_rb;

    public float Bullet_Speed = 100f;


    private int Bullet_attack_point;

    private Bullet_sound BSound;


    private void Awake()
    {
        BSound = GetComponent<Bullet_sound>();
    }

    void Start()
    {
        Bullet_rb = GetComponent<Rigidbody>();

        Shot_bullet();

        Destroy(this.gameObject, 5f);
    }


    public void Shot_bullet()
    {

        Bullet_rb.AddForce(transform.forward * Bullet_Speed, ForceMode.Impulse);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Tank_HP>())
        {
            collision.gameObject.GetComponent<Tank_HP>().Damage(Bullet_attack_point);
        }

   

        BSound.Bullet_end();

        Destroy(this.gameObject);


    }

    public void Set_attack_point(int _Attack_point)
    {
        Bullet_attack_point = _Attack_point;
    }
}
