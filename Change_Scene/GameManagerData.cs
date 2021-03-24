using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//ゲームマネージャーの内容
namespace Select_tank
{
    [CreateAssetMenu(fileName = " GamaManagerData", menuName = "GameManagerData")]
    public class GameManagerData : ScriptableObject
    {
        //選択されたステージを保持、遷移を管理
        [SerializeField]
        private string StageName;

        //選択されたタンクを保持、ステージで生成される
        [SerializeField]
        private GameObject Tank;


        //選択されたステージのidを保持、クリアを管理
        [SerializeField]
        public int Now_stage_id;

        //ステージクリアを管理、既クリアなら1未クリアなら0
        [SerializeField]
        public bool[] Stages = new bool[10];



        //初期化
        private void OnEnable()
        {
            Debug.Log("a");
            if (SceneManager.GetActiveScene().name == "Select_tank")
            {
                StageName = "";
                Tank = null;
            }        
        }

        //ステージ名セットとゲット
        public void Set_StageName(string _StageName)
        {
            StageName = _StageName;
           
        }

        public void Set_StageId(int _Stage_id)
        {
            Now_stage_id = _Stage_id;
        }

        public string Get_StageName()
        {
            return StageName;
        }

        //選択したタンクセットとゲット
        public void Set_tank(GameObject _Tank)
        {
            Tank = _Tank;
        }

        public GameObject Get_tank()
        {
            return Tank;
        }
    }
}
