using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;
public class Task_controller : MonoBehaviour
{
    //Taskを管理
    //普通のステージで用いるGame_masterを流用したい

    private Tutorial _tutorial;
    private List<Tutorial> _tutorial_list;

    [SerializeField]
    private GameObject Task_panel;

    [SerializeField]
    private Text Task_title;

    [SerializeField]
    private Text Task_text;

    private Animator _animator;

    //現在のタスク
    [SerializeField]
    private int Task_cheker = 0;

    //タスクの数-1
    [SerializeField]
    private int Task_amount = 6;

    //タスクをクリアしたか
    private bool Task_flg = false;

    //タスククリアの円
    [SerializeField]
    private Image Success_ring;
    private Animator Success_anim;

    //タスククリアの音
    private AudioSource SE;

    [SerializeField]
    private AudioClip Success;
    [SerializeField]
    private AudioClip Enemy_cre;


    //最終タスク用トレーニング固定砲台
    [SerializeField]
    private GameObject Tutorial_battery;

    private Vector3 Battery_pos1 = new Vector3(200, 21, 1800);
    private Vector3 Battery_pos2 = new Vector3(1800, 21, 1800);
    private Vector3 Battery_pos3 = new Vector3(1000, 21, 1000);

    //最終タスク用アイテム生成
    [SerializeField]
    private GameObject Item_cont;


    //終了条件を設定するために必要
    [SerializeField]
    private Game_master GM;


    void Start()
    {
        //終了条件
        　GM.Enemy = 3;

        //各パートをリストに格納
        _tutorial_list = new List<Tutorial>()
        {
            new Move_task(),
            new Turn_task(),
            new Shot_task(),
            new Zoom_task(),
            new Map_task(),
            new Fight_task(),
            new Success_task(),

        };

        //Panelを出し入れするためのアニメーション
        _animator = Task_panel.GetComponent<Animator>();

        //初めのパートを更新
        Task_update(_tutorial_list[Task_cheker]);
        Change_task();

        //task達成を表示する準備
        Success_anim = Success_ring.GetComponent<Animator>();
        Success_ring.fillAmount = 0;

        SE = GameObject.Find("SE").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Task_cheker <= Task_amount)
        {
            //セットされているチュートリアルの内容をクリアしている　かつ　タスクをクリアしていない　かつ
            //ゲームが開始している(GM.Enemy_move_flgでゲーム開始を判断できるため流用）
            if (_tutorial_list[Task_cheker].Check_task() && !Task_flg && GM.Enemy_move_flg)
            {
                Task_flg = true;
                StartCoroutine("Success_task");
                Task_cheker++;
            }

        }

    }

    //クリアした2秒後にパネルを下げる
    IEnumerator Success_task()
    {
        //クリアの円のアニメーションを再生
        Success_anim.SetTrigger("Success_flg");


        yield return new WaitForSeconds(2.0f);
        SE.PlayOneShot(Success);

        //taskパネルをしまう
        _animator.SetTrigger("Panel_out");
        StartCoroutine("Next_task");
       

    }

    //パネルを下げた2秒後に新しいtaskを表示
    IEnumerator Next_task()
    {
        

        yield return new WaitForSeconds(2.0f);

        //クリアの円を初期状態に戻す
        Success_ring.fillAmount = 0;
        

        Change_task();

        Task_update(_tutorial_list[Task_cheker]);
        Task_flg = false;
    }


    public void Change_task()
    {
        _animator.SetTrigger("Panel_in");
     
    }

    void Task_update(Tutorial tutorial)
    {
        Task_title.text = tutorial.Set_title();
        Task_text.text = tutorial.Set_text();

        //Fight_task時
        if (Task_cheker == 5)
        {
            //アイテム生成
            Item_cont.GetComponent<Tutorial_item>().Item_create();

            //敵砲台生成
            SE.PlayOneShot(Enemy_cre);

            Instantiate(Tutorial_battery, Battery_pos1, Quaternion.Euler(0, 0, 0));
            Instantiate(Tutorial_battery, Battery_pos2, Quaternion.Euler(0, 0, 0));
            Instantiate(Tutorial_battery, Battery_pos3, Quaternion.Euler(0, 0, 0));

            //終了条件設定
            GM.Enemy = 3;
            GM.Mission_achievement.maxValue = GM.Enemy;
            GM.Mission_achievement.value = 0;
            GM.Drawing_mission();
        }
    }

    public void Dest_enemy()
    {
        _tutorial_list[Task_cheker].Dest_enemy();
        GM.Kill_enemy();

    }
}
