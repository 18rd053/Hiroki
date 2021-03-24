using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Game_master : MonoBehaviour
{
    //試合開始と終了を管理
    //敵オブジェクトの移動開始を制御


    public bool Enemy_move_flg = false;
    public bool Start_game_flg = false;


    //シーン開始のアニメーション
    [SerializeField]
    private Change_scene_panel _Change_scene_Panel;

    //ゲームスタートカウントダウン
    [SerializeField]
    private GameObject Start_canvas;

    //それぞれ必要に応じて生成
    [SerializeField]
    private GameObject End_Win_canvas;
    [SerializeField]
    private GameObject End_Lose_canvas;

    //敗北時の爆発
    [SerializeField]
    private ParticleSystem Lose_ex_ef;

    //破壊目標数
    GameObject[] Enemies;
    public int Enemy;

    //目標を表示するためのツール
    //目標数
    [SerializeField]
    private Text Enemy_number;
    //目標達成率
    [SerializeField]
    public Slider Mission_achievement;

    private void Awake()
    {
        Start_canvas.SetActive(false);
    }


    void Start()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Enemy = Enemies.Length;
        Mission_achievement.maxValue = Enemies.Length;
        Mission_achievement.value = 0;
        Drawing_mission();

        //ステージ中盤などから敵が出現するステージで即終了することを防ぐ
        if (Enemy == 0) Enemy = 1;

        _Change_scene_Panel.Open_scene_action();
        StartCoroutine("Start_countdown");
    }

    void FixedUpdate()
    {
        if (Enemy == 0)
        {
            Win();
        }
    }

    public IEnumerator Start_countdown()
    {
        yield return new WaitForSeconds(1.5f);
        Start_canvas.SetActive(true);
    }

    public void Win()
    {
        //行動不可、勝利時ボイス、勝利時BGM、勝利時Canvas
        GameObject.FindObjectOfType<User_action>().Set_user_action(false);
        GameObject.FindObjectOfType<Charactor_voice>().GetComponent<Charactor_voice>().Win_voice();
        GameObject.FindGameObjectWithTag("BGM").GetComponent<BGM_controller>().Change_BGM_Win(true);
        Instantiate(End_Win_canvas);
        //マウス非表示を解除
        GameObject.FindObjectOfType<Player>().Mouse_hide = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //ステージクリアを保存
        PlayerPrefs.SetInt("Stage_clear", 1);
        PlayerPrefs.Save();

        Debug.Log(PlayerPrefs.GetInt("Stage_Clear"));
        Destroy(this);
    }

    public void Lose(Vector3 Die_pos)
    {
        //敗北時BGM、勝利時Canvas,エフェクト
        GameObject.FindGameObjectWithTag("BGM").GetComponent<BGM_controller>().Change_BGM_Lose(true);
        Instantiate(Lose_ex_ef, Die_pos, Quaternion.identity);
        Instantiate(End_Lose_canvas);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Destroy(this);
    }

    public void Set_Enemy_flg(bool boo)
    {
        Enemy_move_flg = boo;
    }

    public void Set_Start_flg(bool boo)
    {
        Start_game_flg = boo;
    }

    public void Kill_enemy()
    {
        Enemy--;
        Mission_achievement.value++;
        Drawing_mission();
        Debug.Log(Enemy);
    }

    public void Drawing_mission()
    {
        Enemy_number.text = Mission_achievement.value.ToString() + "/" + Mission_achievement.maxValue.ToString();
    }


}
