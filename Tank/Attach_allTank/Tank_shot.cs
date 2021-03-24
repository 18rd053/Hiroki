using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tank_shot : MonoBehaviour
{

    //砲身の空オブジェクト(Gun_pos)に取り付けるスクリプト 、弾の生成、リロード表示を行う。
    public GameObject Bullet;

    /// <summary>
    /// メインの戦車スクリプト に情報を渡され射撃を管理
    /// </summary>
    private float Bullet_reload_time;
    private int Bullet_attack_point;
    public int Bullet_Capacity = 0;
    ///

    private float Now_reload;

    ///Bulletのリロード状況を画面上に表示するためのUI

    [SerializeField]
    private Slider Reload_bar;
    [SerializeField]
    private Image Reload_color;
    private bool Reload_max_flg = false;

    //Bulletのリロード状況をshotカメラに表示するための画像
    [SerializeField]
    private Image Reload_img;


    private bool Shot_flg = true;

    [SerializeField]
    private Tank_move_sound TMSound;

    private Charactor_voice Cv;

    //shot時のエフェクト
    [SerializeField]
    private ParticleSystem Shot_smoke;





    void Start()
    {  

        Cv = transform.root.gameObject.GetComponent<Charactor_voice>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Shot_flg)
        {
            if (!Reload_max_flg)
            {
                if (Now_reload >= Bullet_reload_time) Reload_max();
                Now_reload += Time.deltaTime;
                Reload_bar.value = Now_reload;
                Reload_img.fillAmount = Now_reload / Bullet_reload_time;

            }
            else if (Reload_max_flg)
            {
                if(EventSystem.current.IsPointerOverGameObject())return;
                if (Input.GetMouseButtonDown(0)) Shot_bullet();
            }
        }
    }

    public void Set_shot(float _Bullet_reload_time, int _Bullet_attack_point)
    {
        Bullet_reload_time = _Bullet_reload_time;
        Bullet_attack_point = _Bullet_attack_point;
        Reload_bar.maxValue = _Bullet_reload_time;
        Now_reload = _Bullet_reload_time;
        Reload_bar.value = Now_reload;
    }

    public void Set_Capacity(int _Capacity)
    {
        Bullet_Capacity = _Capacity;
    }

    private void Reload_max(){
        Reload_max_flg = true;
        Reload_color.color = new Color32(0, 255, 0, 255);
        Reload_img.color = new Color32(0, 255, 0, 150);

    }

    private void Shot_bullet()
    {
        Reload_color.color = new Color32(255, 255, 0, 255);
        Reload_img.color = new Color32(255, 255, 0, 150);
        Reload_max_flg = false;
        Now_reload = 0f;
        var _Bullet = Instantiate(Bullet, transform.position, transform.rotation);
        _Bullet.GetComponent<Bullet>().Set_attack_point(Bullet_attack_point);
        if (Bullet_Capacity > 0) Bullet_Capacity--;

        iTween.RotateBy(gameObject.transform.parent.gameObject, iTween.Hash("x", -0.1f));

        Shot_smoke.Play();
        TMSound.Shot_start();
        Cv.Attack();
    }



    public void Set_flg(bool boo)
    {
        Shot_flg = boo;
    }


}
