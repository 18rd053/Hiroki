using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_push : MonoBehaviour
{
    //ポーズボタン内のボタンが押された時に音を再生
    //各ボタンのpush時に設定

    [SerializeField]
    private AudioClip Push_button;

    [SerializeField]
    private AudioSource SE;

    private void Start()
    {
        SE = GameObject.FindWithTag("SE").GetComponent<AudioSource>();
    }

    public void Button_push()
    {
        this.SE.PlayOneShot(Push_button);
    }

}
