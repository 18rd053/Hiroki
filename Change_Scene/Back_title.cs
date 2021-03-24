using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Back_title : MonoBehaviour
{
    public void Push_Back_title_button()
    {
        StartCoroutine("LoadTitle");

        if(GetComponent<Button>()) GetComponent<Button>().enabled = false;
    }

    public IEnumerator LoadTitle()
    {
        var async = SceneManager.LoadSceneAsync("Title");

        async.allowSceneActivation = false;
        yield return new WaitForSeconds(1);
        async.allowSceneActivation = true;
    }

}
