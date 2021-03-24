using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    //ポーズ画面を管理、画面上のボタンかescキーで表示
    //pouse時はカーソルを非固定で表示
    //固定非表示はPlayerで管理

    //[SerializeField] private GameObject Tank_canvas;

    [SerializeField]
    private GameObject Pouse;

    [SerializeField]
    private GameObject Volumu_con;

    private bool canvas_flg = true;
    //[SerializeField]private GameObject _Audio_controller;
   
    void Start()
    {
        //Tank_canvas.SetActive(true);
        Pouse.SetActive(false);
        Volumu_con.SetActive(false);
    }

   
    void Update()
    {
       
        if (//Tank_canvas.activeSelf
            canvas_flg &&
            Input.GetKeyDown(KeyCode.Escape))
        {
            //Tank_canvas.SetActive(false);
            canvas_flg = false;
            Pouse.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Time.timeScale = 0f;
        }
        else if (//!Tank_canvas.activeSelf
            !canvas_flg &&
            Input.GetKeyDown(KeyCode.Escape))
        {
            //var Audio_con = _Audio_controller.GetComponent<Audio_controller>();
            //Audio_con.Control_audio_flg(false);

            //Tank_canvas.SetActive(true);
            canvas_flg = true;
            Pouse.SetActive(false);
            Volumu_con.SetActive(false);
        

            Time.timeScale = 1f;
        }
    }

    public void Change_canvase()
    {
        if (//Tank_canvas.activeSelf
            canvas_flg)
        {
            //Tank_canvas.SetActive(false);
            canvas_flg = false;
            Pouse.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Time.timeScale = 0f;
        }
        else if(//!Tank_canvas.activeSelf
             !canvas_flg)
        {
            //var Audio_con = _Audio_controller.GetComponent<Audio_controller>();
            //Audio_con.Control_audio_flg(false);

            //Tank_canvas.SetActive(true);
            canvas_flg = true;
            Pouse.SetActive(false);
            Volumu_con.SetActive(false);

            Time.timeScale = 1f;
        }
            

    }
}
