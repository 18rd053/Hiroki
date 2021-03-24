using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;

public class Set_data : MonoBehaviour
{
    //各タンクの性能を反映
    //押されたボタンからScriptabkeObjectを受け取り中のデータで上書き

    [SerializeField]
    private Text Tank_name;
    [SerializeField]
    private Slider Attack_slider;
    [SerializeField]
    private Slider HP_slider;
    [SerializeField]
    private Slider Speed_slider;
    [SerializeField]
    private Slider Reload_slider;

    [SerializeField]
    private Text SPattack;

    [SerializeField]
    private Image Charactor_img;
    [SerializeField]
    private Text Charactor_name;


    public AudioClip Charactor_voice;


    //現在表示しているタンクを格納
    private GameObject Select_tank;

    private GameObject Select_tank_tmp;

    private Vector3 Display_pos = new Vector3(11f, 0.2f, -18f);

    public Tank_data _Tank_data;


    public AudioSource Voice;


    //取得した情報に表示を切り替える。
    public void Get_data(ScriptableObject TD)
    {
        _Tank_data = (Tank_data)TD;

        Tank_name.text = _Tank_data.Name;
        Attack_slider.value = _Tank_data.Attack;
        HP_slider.value = _Tank_data.HP;
        Speed_slider.value = _Tank_data.Speed;
        Reload_slider.value = _Tank_data.Reload;

        SPattack.text = _Tank_data.SPattack;
        Charactor_img.sprite = _Tank_data.Charactor_img;
        Charactor_name.text  = _Tank_data.Charactor_name;
        Charactor_name.color = _Tank_data.Charactor_name_color;

        Charactor_voice = _Tank_data.Charactor_voice;
        Select_tank = _Tank_data.Tank_prfb;
        Select_tank_draw();
    }

    public void Select_tank_draw()
    {
        if (Select_tank_tmp != null) Destroy(Select_tank_tmp);
        Select_tank_tmp = Instantiate(Select_tank, Display_pos, transform.rotation);
    }

    public void Puch_confirm()
    {
        Voice.PlayOneShot(Charactor_voice);
    }
}
