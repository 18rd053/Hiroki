using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn_turret_flg : MonoBehaviour
{
    /// <summary>
    /// Tankのturretの回転を制限
    /// </summary>
   
    //動くことが可能な時true
    public bool turn_flg = true;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.root.CompareTag("Ground"))
        {
            Debug.Log("col" + gameObject.name);
            turn_flg = false;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.transform.root.CompareTag("Ground"))
        {
            Debug.Log("col_exit" + gameObject.name);
            turn_flg = true;
        }
    }
}
