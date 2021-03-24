using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_EF : MonoBehaviour
{
    [SerializeField]
    private GameObject Coll_ground;




    private void OnCollisionEnter(Collision collision)
    {
     
        Instantiate(Coll_ground,this.transform.position,transform.rotation);
    }

    public void Bullet_dest()
    {
        Instantiate(Coll_ground, this.transform.position, transform.rotation);
    }
}
