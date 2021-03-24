using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Select_tank
{
    public class Clear_stage_check : MonoBehaviour
    {
        private GameManagerData _GameManagerData;

        //各ステージのクリア表示用画像
        public Image[] Stage_clear_img;

        private void Awake()
        {
            _GameManagerData = FindObjectOfType<GameManager>().Get_GameManageraData();

            //クリアフラグを立てる
            if (PlayerPrefs.GetInt("Stage_clear") == 1)
                {
                    Debug.Log("c");
                    _GameManagerData.Stages[_GameManagerData.Now_stage_id] = true;
                    PlayerPrefs.SetInt("Stage_clear", 0);
                    PlayerPrefs.Save();

                    Debug.Log(PlayerPrefs.GetInt("Stage_Clear"));
                }
           

            //クリアしているステージを確認
            for (int i = 0 ; i < _GameManagerData.Stages.Length ; i++)
            {
                //クリアしているならクリア表示用画像を描画
                if (_GameManagerData.Stages[i]) Stage_clear_img[i].enabled = true;
            }
        }
    }
}