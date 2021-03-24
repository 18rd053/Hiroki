using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_scene : MonoBehaviour
{
    [SerializeField]
    private Change_scene_panel Mask;

    
    void Start()
    {
        Mask.Open_scene_action();
    }

}
