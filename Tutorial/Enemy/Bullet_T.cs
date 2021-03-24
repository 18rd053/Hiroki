using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_T : MonoBehaviour
{ 
    //弾自体に取り付けるスクリプト 、自壊とスピードを加える。
    Rigidbody Bullet_rb;

    //当たった場所と発射した瞬間に爆発衝撃
    [SerializeField]
    private float Force = 100f;
    [SerializeField]
    private float Radius = 10f;


    public float Bullet_Speed = 100f;


    //attackポイントはTank_shotから受け取る
    private int Bullet_attack_point;

    //[SerializeField]
    private Bullet_sound BSound;

    void Start()
    {
        Bullet_rb = GetComponent<Rigidbody>();

        BSound = GetComponent<Bullet_sound>();


        Shot_bullet();
        Destroy(this.gameObject, 5f);
    }


    public void Shot_bullet()
    {

        Bullet_rb.AddForce(transform.forward * Bullet_Speed);
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

    public void Set_attack_point(int _Bullet_attack_point)
    {
        Bullet_attack_point = _Bullet_attack_point;
    }
}
