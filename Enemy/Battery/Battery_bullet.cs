using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery_bullet : MonoBehaviour
{

    //敵の弾自体に取り付けるスクリプト 、自壊とスピードを加える。
    Rigidbody Bullet_rb;

  
    public float Bullet_Speed = 200f;

    private int Bullet_attack_point;

    
    //弾が衝突した時に再生
    [SerializeField]
    private ParticleSystem Bullet_coll;

    // Start is called before the first frame update
    void Start()
    {
        Bullet_rb = GetComponent<Rigidbody>();

        Shot_bullet();
        Destroy(this.gameObject, 3f);
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


        Instantiate(Bullet_coll, transform.position, transform.rotation);

        Destroy(this.gameObject);


    }

   

    public void Set_bullet_data(int _Bullet_attack_point , int Bullet_size)
    {
        Bullet_attack_point = _Bullet_attack_point;
        transform.localScale = new Vector3(Bullet_size, Bullet_size, Bullet_size);
    }
}
