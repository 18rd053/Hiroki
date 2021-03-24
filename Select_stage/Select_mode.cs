using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Select_mode : MonoBehaviour
{
    ///モードを選んだら選ばれたモードに応じてcanvasと背景表示

    //モード選択後ステージを選択するためのcanvas
    public Canvas[] Stages;

    //背景描画用
    [SerializeField]
    private Image Background_img;
    //各ステージの背景用イメージ
    public Sprite[] Stages_img;


    private void Start()
    {
        Reset();
    }

    //モード選択からステージ番号を受け取りステージを表示
    public void Press_Mode(int Stage_number)
    {
        Background_img.color = Color.white;

        Reset();
        Stages[Stage_number].enabled = true;
        Background_img.sprite = Stages_img[Stage_number];
    }

    public void Reset()
    {
        foreach (var Canvas in Stages)
            Canvas.enabled = false;
    }



}
