using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Start_countdown : MonoBehaviour
{
    [SerializeField]
    private Image Count_down_img;
    [SerializeField]
    private Image Count_down_img_back;

    [SerializeField]
    private Text Count_down_number;

    [SerializeField]
    private Animator Start_mission_anim;

    private float Count_down;

    //ユーザーの入力を管理
    private User_action _User_Action;


    // Start is called before the first frame update
    void Start()
    {
        Count_down = 3;

        _User_Action = GameObject.FindObjectOfType<User_action>();
       

        Count_down_img.color = Color.green;
        Count_down_img.fillAmount = 1;

        var Count_down_int = (int)Count_down;
        Count_down_number.text = Count_down_int.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Count_down -= Time.deltaTime;
        Count_down_img.fillAmount -= Time.deltaTime;

        

        if (Count_down <= 2 && Count_down > 1 && Count_down_number.text != "2")
        {
            Count_down_img.color = Color.yellow;
            Count_down_img.fillAmount = 1;
            var Count_down_int = (int)Mathf.Ceil(Count_down);
            Count_down_number.text = Count_down_int.ToString();
        }
        else if (Count_down <= 1 && Count_down > 0 && Count_down_number.text != "1")
        {
            Count_down_img.color = Color.red;
            Count_down_img.fillAmount = 1;
            var Count_down_int = (int)Mathf.Ceil(Count_down);
            Count_down_number.text = Count_down_int.ToString();
        }
        else if (Count_down < 0 && Count_down_number.text != "0")
        {
            Count_down_number.text = 0.ToString();
            Count_down_img.enabled = false;
            Count_down_img_back.enabled = false;
            Count_down_number.enabled = false;

            
            Start_mission_anim.SetTrigger("Start_mission_trg");
        }
    }

    //アニメーション終了時に呼ばれ非アクティブ化
    public void Canvas_notActive(){
       　//自機の操作開始
        _User_Action.Set_user_action(true);
        //親であるゲームマスターのフラグを変え敵機が動けるようにする
        gameObject.transform.root.GetComponent<Game_master>().Set_Enemy_flg(true);


        gameObject.SetActive(false);

        }

}
