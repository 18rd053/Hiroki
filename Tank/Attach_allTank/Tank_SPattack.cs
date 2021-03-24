using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_SPattack : MonoBehaviour
{

    //SPattackを発動してもいいか判断
    private bool SP_flg = true;

    //SPattackの演出を行っているか判断
    private bool _SPflg = false;

    public int SPpoint = 0;


   
    [SerializeField]
    private GameObject SPattack_controller;

    [SerializeField]
    private User_action _User_action;

    //SPattackを発動可能かを示す
    [SerializeField]
    private SP_charge SP_charge;


    //SP演出用
    [SerializeField]
    private Camera SPcamera;

    //SPattack説明用パネル
    [SerializeField]
    private GameObject SP_panel;

    private Animator SPanimator;

    private float SPeffct_time = 1.2f;
    //SP演出用

    //SP発動中
    [SerializeField]
    private ParticleSystem SPeffect;

    //音関連
    private Charactor_voice Cv;

    private BGM_controller _BGM_controller;

    private AudioSource BGM;

    [SerializeField]
    private Tank_move_sound TMSound;


    private void Awake()
    {
        //音
        Cv = GetComponent<Charactor_voice>();

        _BGM_controller = GameObject.FindWithTag("BGM").GetComponent<BGM_controller>();
    }

    void Start()
    {
        //SPattakが使用可能か示すアウトラインを設定
        SP_charge.gameObject.SetActive(false);
        

        //SPattack発動中のパーティクル
        SPeffect.Stop();

        SPcamera.enabled = false;

        SP_panel.SetActive(false);

        SPanimator = SPcamera.GetComponent<Animator>();

    }


    public bool Check_SPattack()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (SPpoint > 0 && SP_flg)
            {
                SPattack_Active();
                return true;
            }
            return false;
        }
        return false;
    }

    //条件を満たしたら呼ばれるSPアタック発動時の処理
    private void SPattack_Active()
    {

        //発動に必要なポイントを減らす
        SPpoint -= 1;

        //ユーザからの一部操作を無効
        _User_action.Set_user_action(false);

        //SPattack中、演出情報を受け取り、操作不可能時間を設定
        SPanimator.SetTrigger("SPattack");


        SPflg_true();

        SPattack_controller.SetActive(true);

        if (SPpoint == 0)
        {
            //発動可能であることを示すアウトラインを消す
            SP_charge.gameObject.SetActive(false);
        }

        //SPattack中のエフェクトを再生
        SPeffect.Play();
        Cv._SPattack();
        TMSound.SPattack();

        //SPattack用のBGMに切り替える
        _BGM_controller.Change_BGM_SP(true);

        //Invoke("SPattack_end", 30);

        //SPattack開始演出終了
        Invoke("SPflg_false", SPeffct_time);
    }

    //SPballを取得
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SPball")
        {
            TMSound.SPball_get();
            SPpoint += 1;
            Destroy(collision.gameObject);

            //SPattack発動可能であることを示すアウトラインを機体に表示
            SP_charge.gameObject.SetActive(true);


        }
    }

    

    public void SPflg_true()
    {
        SPcamera.enabled = true;
        _SPflg = true;
    }


    public void SPflg_false()
    {
        _SPflg = false;
        SPcamera.enabled = false;
        SPattack_controller.SetActive(false);
        SP_panel.SetActive(true);
        _User_action.Set_user_action(true);
    }


    //SPattack終了(BGMなどを元に戻す)
    public void SPattack_end()
    {
        SPeffect.Stop();
        _BGM_controller.Change_BGM_SP(false);
        SP_panel.SetActive(false);
    }


    public void Set_flg(bool boo)
    {
        SP_flg = boo;
    }

    public void Set_SPattack_BGM(AudioClip SPBGM)
    {
        //受け取ったBGMをBGMコントローラーにセット
        _BGM_controller.Set_SPattack_BGM(SPBGM);
    }
    
}
