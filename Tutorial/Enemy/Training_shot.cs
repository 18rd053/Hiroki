using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training_shot : MonoBehaviour
{

    [SerializeField]
    private GameObject Bullet;
 
    private float Shot_time = 5.0f;

    private float Now_shot_time = 0f;

    private int Bullet_attack_point = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Now_shot_time += Time.deltaTime;

        if (Shot_time <= Now_shot_time)
        {
            Now_shot_time = 0.0f;
            var T_Bullet = Instantiate(Bullet,transform.position,transform.rotation);
            T_Bullet.GetComponent<Bullet_T>().Set_attack_point(Bullet_attack_point);

            Shot_time = Random.Range(1, 5);
        }
    }
}
