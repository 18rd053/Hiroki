using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class Big_Map : MonoBehaviour
{
    //Big_Map本体に取り付ける
    [SerializeField]
    public GameObject Big_map;

    //開いている時はtrue
    [SerializeField]
    private bool Map_flg = false;
    
    [SerializeField]
    private Animator _Open_Map_anim;

    [SerializeField]
    private Tank_move_sound TMSound;

    void Start()
    {
        transform.localScale = new Vector3(0, 0, 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {

            //開いているならMap_flg = true

            //閉じる
            if(Map_flg)
            {
                _Open_Map_anim.SetTrigger("Close_Map");
                transform.localScale = new Vector3(0, 0, 0);
                Big_map.SetActive(false);
                Map_flg = false;
                TMSound.Map();
                
            }
            else
            //開く
            {
         
                _Open_Map_anim.SetTrigger("Open_Map");
                Big_map.SetActive(true);
                Map_flg = true;
                TMSound.Map();

            }
            

        }

    }
}
