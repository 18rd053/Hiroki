using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_camera : MonoBehaviour
{
    /// <summary>
    /// 本体にアタッチ、右クリックでカメラをズーム
    /// </summary>

    [SerializeField]
    private Camera Move_camera;

    [SerializeField]
    private Camera Shot_camera;

    //ぼかし処理のため
    [SerializeField]
    private GameObject Shot_cameras;


    [SerializeField]
    private Tank_move_sound TMSound;    


    //Shot_cameraのFOVを変更する範囲
    private readonly int Zoom_max = 10;
    private readonly int Zoom_min = 60;

    //射撃モード時に非アクティブ
    [SerializeField]
    private GameObject Main_canvas;

    //射撃モード時に表示
    [SerializeField]
    private Canvas Shot_canvas;
    
    /*
    [SerializeField]
    private Animator Aim_mask;
    */
    [SerializeField]
    private Main_Camera_con _Main_Camera_Con;

    private bool Changecam_flg = true;
    
    void Start()
    {
        Move_camera.enabled = true;
        Shot_camera.enabled = false;
        Shot_canvas.enabled = false;

        Shot_cameras.SetActive(false);
    }

  
    void FixedUpdate()
    {
        if (Changecam_flg)
        {
            if (Input.GetMouseButtonUp(1)) Change_move_camera();
            if (Input.GetMouseButtonDown(1)) Change_shot_camera();
        }
    }


    //移動モードに移行
    private void Change_move_camera()
    {
        Shot_camera.fieldOfView = Zoom_min;
        TMSound.Change_camera();
        Move_camera.enabled = true;
        Shot_camera.enabled = false;
        Main_canvas.SetActive(true);
        Shot_canvas.enabled = false;
        _Main_Camera_Con.Change_zoom_shot_flg(false);

        Shot_cameras.SetActive(false);
    }

    //射撃モードに移行
    private void Change_shot_camera()
    {
        Shot_cameras.SetActive(true);

        TMSound.Change_camera();
        Move_camera.enabled = false;
        Shot_camera.enabled = true;
        Main_canvas.SetActive(false);
        Shot_canvas.enabled = true;
        
        _Main_Camera_Con.Change_zoom_shot_flg(true);
    }

    public void Set_flg(bool boo)
    {
        Changecam_flg = boo;
    }

}
