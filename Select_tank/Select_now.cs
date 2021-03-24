using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class Select_now : MonoBehaviour
{
    //現在選択しているTankを示す
    [SerializeField]
    private Image Tank_Image1;

    [SerializeField]
    private Image Tank_Image2;

    [SerializeField]
    private Image Tank_Image3;

    void Start()
    {
        All_false();
    }

    public void Back_img(int number)
    {
        All_false();

        if(number == 1)
        {
            Tank_Image1.enabled = true;
        }
        else if(number == 2)
        {
            Tank_Image2.enabled = true;
        }
        else if(number == 3)
        {
            Tank_Image3.enabled = true;
        }
    }

    public void All_false()
    {
        Tank_Image1.enabled = false;
        Tank_Image2.enabled = false;
        Tank_Image3.enabled = false;
    }
}
