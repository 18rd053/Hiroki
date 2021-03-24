using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;
public class Hide_window : MonoBehaviour
{
    //Hボタンを押されたらtaskを隠す

    [SerializeField]
    private GameObject Task_panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (Task_panel.activeSelf)Task_panel.SetActive(false);
            else if (!Task_panel.activeSelf)Task_panel.SetActive(true);
        }
    }
}
