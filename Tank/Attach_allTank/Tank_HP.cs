using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;
public class Tank_HP : MonoBehaviour
{

    /// <summary>
    /// HPを制御、衝突した弾から攻撃力を受け取りダメージ計算、バーに反映
    /// </summary>
   
    private int Hp;
    private int Hp_Max;

    private int Life = 1;
    
    [SerializeField]
    private Slider _Hp_bar;

    [SerializeField]
    private Text Hp_value;


    [SerializeField]
    private Tank_move_sound TMSound;

    private Charactor_voice Cv;

    //ゲームを終了処理
    private GameObject GM;

    ///ユーザーのキー入力を不可能にする
    [SerializeField]
    private User_action _User_action;
  
    void Start()
    {
        Cv = transform.root.gameObject.GetComponent<Charactor_voice>();

        GM = GameObject.FindWithTag("GM");
        Hp_update();
    }

    //ダメージを受けたら受けたダメージ分HPをマイナス
    public void Damage(int Attack_point)
    {

        if (Hp - Attack_point < 0) Hp = 0;
        else if (Hp > 0)
        {
            Hp -= Attack_point;
            Cv.Damage();
        }

        

        if (Hp == 0 && Life ==1)
        {
            Life --;
            //ユーザ入力を不可能にする
            _User_action.Set_user_action(false);
            var _GM = GM.GetComponent<Game_master>();
            Cv.Lose_voice();
            TMSound.Lose_SE();

            _GM.Lose(transform.position);
        }
        Hp_update();
    }

    //HPの状態をTextとバーに反映
    public void Hp_update()
    {
        _Hp_bar.maxValue = Hp_Max;
        _Hp_bar.value = Hp;

        Hp_value.text = Hp + "/" + Hp_Max;
    }

    //item(Repair)を拾ったらHPを50回復してitemを破壊
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Repair")
        {
            TMSound.Heal();

            Hp += 50;
            Hp_Max += 50;
            Hp_update();
            Destroy(collision.gameObject);
        }
    }

    public void Set_hp(int _Hp)
    {
        Hp_Max = _Hp;
        Hp = _Hp;
    }

}
