using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class Training_status : MonoBehaviour
{
    //チュートリアル用砲台

    private AudioSource Enemy_SE;

    [SerializeField]
    private AudioClip Dest;

    //HP管理
    private int Enemy_HP = 50;

    [SerializeField]
    private Slider _Hp_bar;


    //破壊された時のエフェクト
    [SerializeField]
    private GameObject Exp;

    
    [SerializeField]
    private GameObject Task_controller;

    [SerializeField]
    private Canvas Hit_canvas;

    [SerializeField]
    private Canvas Kill_canvas;

    // Start is called before the first frame update
    void Start()
    {
        Task_controller = GameObject.Find("Task_controller");
        Enemy_SE = GetComponent<AudioSource>();
        Hp_update();
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.enabled) {
            _Hp_bar.transform.rotation = Camera.main.transform.rotation;
        }

        if (Enemy_HP <= 0) Destruction();
    }

    //ダメージを受けたら受けたダメージ分HPをマイナス
    public void Damage(int Attack_point)
    {
        if (Enemy_HP - Attack_point < 0)Enemy_HP = 0;
        else if (Enemy_HP >= 0) Enemy_HP -= Attack_point;


        Instantiate(Hit_canvas);

        Hp_update();
    }

    //HPの状態をTextとバーに反映
    public void Hp_update()
    {
        _Hp_bar.value = Enemy_HP;

    }

    public void Destruction()
    {
        Instantiate(Exp,transform.position,Quaternion.identity);
        AudioSource.PlayClipAtPoint(Dest, transform.position, 1);

        Instantiate(Kill_canvas);
        Task_controller.GetComponent<Task_controller>().Dest_enemy();

        Destroy(this.gameObject);
    }


}
