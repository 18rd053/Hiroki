using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;
public class Open_volume : MonoBehaviour
{

    [SerializeField]
    private GameObject Volume_panel;


    public void Push_Volume_button()
    {

        Volume_panel.SetActive(true);

        this.gameObject.SetActive(false);
    }
}
