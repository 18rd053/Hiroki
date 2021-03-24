using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //弾自体に取り付けるスクリプト 、自壊とスピードを加える。
    Rigidbody Bullet_rb;

    //当たった場所と発射した瞬間に爆発衝撃
    [SerializeField]
    private float Force = 2000f;
    [SerializeField]
    private float Radius = 500f;

    //爆発を起こす範囲
    [SerializeField]
    private float Search_exrad = 15f;

    public float Bullet_Speed = 1000f;


    //attackポイントはTank_shotから受け取る
    private int Bullet_attack_point;

    //[SerializeField]
    private Bullet_sound BSound;

    private Bullet_EF BEF;

    private void Awake()
    {
        BSound = GetComponent<Bullet_sound>();
        BEF = GetComponent<Bullet_EF>();
    }

    void Start()
    {
        Bullet_rb = GetComponent<Rigidbody>();


        //Explision_force();
         Shot_bullet();


        StartCoroutine("Bullet_dest");

        
    }

    public IEnumerator Bullet_dest()
    {
        yield return new WaitForSeconds(1f);

        BEF.Bullet_dest();
        Explision_force();
        BSound.Bullet_end();

        Destroy(this.gameObject);

    }


    public void Shot_bullet()
    {
       
        Bullet_rb.AddForce(transform.forward * Bullet_Speed,ForceMode.Impulse);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Training_status>())
        {
            collision.gameObject.GetComponent<Training_status>().Damage(Bullet_attack_point);
        }

        else if (collision.gameObject.GetComponent<Battery_HP>())
        {
            collision.gameObject.GetComponent<Battery_HP>().Damage(Bullet_attack_point);
        }
        else if (collision.gameObject.GetComponent<Enemy_tank_HP>())
        {
            collision.gameObject.GetComponent<Enemy_tank_HP>().Damage(Bullet_attack_point);
        }

        Explision_force();

        BSound.Bullet_end();

        Destroy(this.gameObject);

        
    }

    public void Explision_force()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, Search_exrad);
        foreach (Collider collider in cols)
        {
            if (collider.gameObject.CompareTag("Bullet")) continue;
            if(collider.GetComponent<Rigidbody>())collider.GetComponent<Rigidbody>().
                AddExplosionForce(Force, transform.position, Radius);
        }
    }

    public void Set_attack_point(int _Bullet_attack_point)
    {
        Bullet_attack_point = _Bullet_attack_point;
    }
}
