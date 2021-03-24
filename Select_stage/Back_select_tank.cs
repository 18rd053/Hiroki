using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Back_select_tank : MonoBehaviour
{
    //戻るボタンが押されたら
    public void Push_Backbutton()
    {
        StartCoroutine("Back_scene");
    }

    //　1秒待ってからGameManagerDataに保存されている次のシーンに移動する
    public IEnumerator Back_scene()
    {
        var async = SceneManager.LoadSceneAsync("Select_tank");

        async.allowSceneActivation = false;
        yield return new WaitForSeconds(2);
        async.allowSceneActivation = true;
    }
}
