using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Search_player : MonoBehaviour
{

    [SerializeField]
    private GameObject Battery_rota;

    //追従速度
    public float Lerp_value;

    public bool Player_flg;

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var a = other.transform.position;
            a.y += 10f;
            
            Battery_rota.transform.rotation = Quaternion.Slerp(Battery_rota.transform.rotation,
                Quaternion.LookRotation(//other.transform.position
                    a - Battery_rota.transform.position),
                Time.deltaTime * Lerp_value);

            if(!Player_flg) Player_flg = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Player_flg) Player_flg = false;
        }
    }

    public void Set_lerp_value(float _Lerp_value)
    {
        Lerp_value = _Lerp_value;
    }

    
}
