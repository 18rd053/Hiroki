using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
[CreateAssetMenu]
public class Tank_data : ScriptableObject
{
    public int ID;
    public string Name;
    public int Attack;
    public int HP;
    public int Speed;
    public int Reload;

    public string SPattack;

    public Sprite Charactor_img;
    public string Charactor_name;
    public AudioClip Charactor_voice;
    public Color Charactor_name_color;

    public GameObject Tank_prfb;
    
}
