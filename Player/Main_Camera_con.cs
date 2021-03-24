using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Camera_con : MonoBehaviour
{
    //turretとその下のカメラにつける。
    //turrentとGunにつける
    [SerializeField]
    private Transform verRot_turret;//turret
    [SerializeField]
    private Transform horRot_gun;//Shot_camera//Gun


    [SerializeField]
    private Rigidbody Turret_rb;

    private float Limit_XAxiz_min = -6f;
    private float Limit_XAxiz = 15f;
    private  Vector3 XAxiz;


    //カメラをzoomしている時はマウスでのカメラ移動をゆっくりにする
    private bool Zoom_shot_flg = false;

    //カメラを動かすことができるか
    public bool Zoomcam_flg = true;

    void Start()
    {
        XAxiz = horRot_gun.localEulerAngles;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Zoomcam_flg)
        {
            float X_Rotation = Input.GetAxis("Mouse X");
            float Y_Rotation = Input.GetAxis("Mouse Y");

           

            if (!Zoom_shot_flg)
            {

                Turret_rb.angularVelocity = new Vector3(0, X_Rotation * 2f, 0);
                
                var x = XAxiz.x + Y_Rotation * 2f;
                if (x >= Limit_XAxiz_min && x <= Limit_XAxiz)
                {
                    XAxiz.x = x;
                    horRot_gun.localEulerAngles = -XAxiz;
                }

            }//射撃モード時はカメラの動きを小さく
            else if (Zoom_shot_flg)
            {
                Turret_rb.angularVelocity = new Vector3(0, X_Rotation * 0.5f, 0);
                var x = XAxiz.x + Y_Rotation * 0.5f;
                if (x >= Limit_XAxiz_min && x <= Limit_XAxiz)
                {
                    XAxiz.x = x;
                    horRot_gun.localEulerAngles = -XAxiz;
                }
            }
        }
    }

    public void Change_zoom_shot_flg(bool boo)
    {
        Zoom_shot_flg = boo;
    }

    public void Set_flg(bool boo)
    {
        Zoomcam_flg = boo;
    }
}