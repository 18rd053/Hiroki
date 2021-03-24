using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

//タンクを選び終わったらステージ選択画面に移動
public class Send_choose_stage : MonoBehaviour
{

    public void Push_button()
    {
        StartCoroutine("Load_select_stage");
    }

    public IEnumerator Load_select_stage()
    {
        var async = SceneManager.LoadSceneAsync("Select_stage");

        async.allowSceneActivation = false;
        yield return new WaitForSeconds(2);
        async.allowSceneActivation = true;
    }
}
