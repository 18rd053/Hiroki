using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//各ステージのゲームマネージャーにつけて選んだタンクを生成
namespace Select_tank
{
    public class Game_start : MonoBehaviour
    {
        private GameManagerData _GameManagerData;

        //スタート位置に設定しておく空オブジェクト
        private GameObject Starting_position_object;

        //初期位置
        private Vector3 Str_pos;


        // Start is called before the first frame update
        void Awake()
        {
            _GameManagerData = FindObjectOfType<GameManager>().Get_GameManageraData();

            Starting_position_object = GameObject.FindWithTag("Starting_position");
            Str_pos = Starting_position_object.transform.position;

            var Player_tank = Instantiate(_GameManagerData.Get_tank(), Str_pos, transform.rotation);
            Player_tank.GetComponent<User_action>().Set_user_action(false); 
        }

    }
}
