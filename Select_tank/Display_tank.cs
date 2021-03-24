using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Display_tank : MonoBehaviour
{
    

    //現在表示しているタンクを格納
    private GameObject Select_tank;

    private Vector3 Display_pos = new Vector3(11f ,0.2f ,-18f);

    public void Select_tank_Button(GameObject Tank_name)
    {
        if (Select_tank != null) Destroy(Select_tank);
        Select_tank = Instantiate(Tank_name,Display_pos,transform.rotation);
    }
}
