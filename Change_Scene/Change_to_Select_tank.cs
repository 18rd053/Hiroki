using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//タイトル画面からタンク選択画面に移動
public class Change_to_Select_tank : MonoBehaviour
{

    [SerializeField]
    private Image Panel;

    private bool Darkening_flg = false;

    // Start is called before the first frame update
    void Start()
    {
        var C = Panel.color;
        Panel.color = new Color(C.r, C.g, C.b, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Darkening_flg)
        {
            var C = Panel.color;
            Panel.color = new Color(C.r ,C.g ,C.b , C.a + 0.02f );
        }

        if (Input.anyKey && !Input.GetMouseButton(0) && !Input.GetMouseButton(1) && !Input.GetMouseButton(2))
        {
            Invoke("Change_scene",1.0f);
            Darkening_flg = true;
        }

    }



    private void Change_scene()
    {
        SceneManager.LoadScene("Select_tank");
    }

}
