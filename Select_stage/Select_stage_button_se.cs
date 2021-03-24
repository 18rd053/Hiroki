using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_stage_button_se : MonoBehaviour
{
    //ステージ選択画面のボタンに適用して音を鳴らす
    [SerializeField]
    private AudioSource SE;
    [SerializeField]
    private AudioClip ModeSelect_SE;
    [SerializeField]
    private AudioClip StageSelect_SE;

    public void Select_Modebutton()
    {
        SE.PlayOneShot(ModeSelect_SE);
    }

    public void Select_Stagebutton()
    {
        SE.PlayOneShot(StageSelect_SE);
    }
}
