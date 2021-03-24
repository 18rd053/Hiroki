using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_scene_panel : MonoBehaviour
{
    [SerializeField]
    private AudioClip Open_Scene;

    [SerializeField]
    private AudioClip Close_Scene;

    [SerializeField]
    private AudioSource SE;

    
    void Awake()
    {
        SE = GameObject.FindWithTag("SE").GetComponent<AudioSource>();
    }

    //シーン切り替え（閉）
    public void Close_scene_action()
    {
        SE.PlayOneShot(Close_Scene);
       　GetComponent<Animator>().SetTrigger("Close_trg");
    }

    //シーン切り替え（開）
    public void Open_scene_action()
    {
        SE.PlayOneShot(Open_Scene);
        GetComponent<Animator>().SetTrigger("Open_trg");
    }
}
