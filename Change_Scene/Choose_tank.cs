using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//タンクを選んでセットする。
namespace Select_tank
{
    public class Choose_tank : MonoBehaviour
    {
        private GameManagerData _GameManagerData;

        [SerializeField]
        private Button Select_stage_button;

        [SerializeField]
        private AudioSource SE;

        [SerializeField]
        private AudioClip Select_se;

        // Start is called before the first frame update
        void Start()
        {
            //GameManagerを取得
            _GameManagerData = FindObjectOfType<GameManager>().Get_GameManageraData();

            //選択されるまではButtonを無効に
            Select_stage_button.enabled = false;

        }

        //キャラクターを選択した時にデータをセット
        public void OnSelect_tank(GameObject Tank)
        {
            SE.PlayOneShot(Select_se);
            EventSystem.current.SetSelectedGameObject(null);
            _GameManagerData.Set_tank(Tank);
            Select_stage_button.enabled = true;
        }

    }
}