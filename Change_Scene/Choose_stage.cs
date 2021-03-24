using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//ステージを選んでセットする。
namespace Select_tank
{
    public class Choose_stage : MonoBehaviour
    {
        private GameManagerData _GameManagerData;

        [SerializeField]
        private Button Game_start_button;

        void Start()
        {
            _GameManagerData = FindObjectOfType<GameManager>().Get_GameManageraData();
            //選択されるまではButtonを無効に
            Game_start_button.enabled = false;
        }

        public void Select_stageName(string StageName)
        {
            //選択されたステージを取得し保存
            _GameManagerData.Set_StageName(StageName);

            //選択されたらゲームを開始できるようにする。
            Game_start_button.enabled = true;

        }

        public void Select_stageId(int _StageId)
        {
            _GameManagerData.Set_StageId(_StageId);
        }

    }
}
