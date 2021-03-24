using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_enemy : MonoBehaviour
{
    //弾自体に取り付けるスクリプト 、自壊とスピードを加える。
    Rigidbody Bullet_rb;

    //当たった場所と発射した瞬間に爆発衝撃
    [SerializeField]
    private float Force = 100f;
    [SerializeField]
    private float Radius = 10f;


    //バレット情報は攻撃スクリプトから受け取る
    private int Bullet_attack_point;
    private float Bullet_speed;
    private float Bullet_scale;

    //[SerializeField]
    private Bullet_sound BSound;

    void Start()
    {
        transform.localScale = new Vector3 (Bullet_scale, Bullet_scale, Bullet_scale);
        Bullet_rb = GetComponent<Rigidbody>();

        BSound = GetComponent<Bullet_sound>();


        Shot_bullet();
        Destroy(this.gameObject, 5f);
    }


    public void Shot_bullet()
    {

        Bullet_rb.AddForce(transform.forward * Bullet_speed);
        Explision_force();

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Tank_HP>())
        {
            collision.gameObject.GetComponent<Tank_HP>().Damage(Bullet_attack_point);
        }


        Explision_force();

        BSound.Bullet_end();

        Destroy(this.gameObject);


    }

    public void Explision_force()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, 7f);
        foreach (Collider collider in cols)
        {
            if (collider.gameObject.tag == "Bullet") continue;
            if (collider.GetComponent<Rigidbody>()) collider.GetComponent<Rigidbody>().
                  AddExplosionForce(Force, transform.position, Radius);
        }
    }

    
    public void Set_enemy_bullet_spec(int _Bullet_attack_point,float _Bullet_Speed, float _Bullet_scale)
    {
        Bullet_attack_point = _Bullet_attack_point;
        Bullet_speed = _Bullet_Speed;
        Bullet_scale = _Bullet_scale;
    }
}
