using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

namespace Select_tank
{
    public class Send_game : MonoBehaviour
    {
        private GameManagerData _GameManagerData;

        private void Start()
        {
            _GameManagerData = FindObjectOfType<GameManager>().Get_GameManageraData();
        }

        //確定ボタンが押されたら
        public void Push_button()
        {
            StartCoroutine("LoadGame");
        }

        //　1秒待ってからGameManagerDataに保存されている次のシーンに移動する
        public IEnumerator LoadGame()
        {
            var async = SceneManager.LoadSceneAsync(_GameManagerData.Get_StageName());

            async.allowSceneActivation = false;
            yield return new WaitForSeconds(2);
            async.allowSceneActivation = true;
        }
    }
}