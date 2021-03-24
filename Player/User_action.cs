using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User_action : MonoBehaviour
{
    //ユーザからの移動入力,カメラ操作を一括でonoffするスクリプト 

    [SerializeField]
    private Tank_move _Tank_Move;

    [SerializeField]
    private Tank_shot _Tank_Shot;

    [SerializeField]
    private Main_Camera_con _Main_Camera_Con;

    [SerializeField]
    private Change_camera _Change_Camera;

    [SerializeField]
    private Tank_SPattack _Tank_SPattack;

    public void Set_user_action(bool boo)
    {
        _Tank_Move.Set_flg(boo);
        _Tank_Shot.Set_flg(boo);
        //_Main_Camera_Con.Set_flg(boo);
        _Change_Camera.Set_flg(boo);
        _Tank_SPattack.Set_flg(boo);
    }
}
