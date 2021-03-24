using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //マウスを隠したい時true
    public bool Mouse_hide;

    void Start()
    {
        Application.targetFrameRate = 60;
        Mouse_hide = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Mouse_hide && Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
