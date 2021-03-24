using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_controller : MonoBehaviour
{
    [SerializeField]
    private AudioSource BGM_source;

    [SerializeField]
    private AudioClip Def_BGM;

    [SerializeField]
    private AudioClip Win_BGM;

    [SerializeField]
    private AudioClip Lose_BGM;


    private AudioClip SPattack_BGM;

    private float _BGM_volume;

    // Start is called before the first frame update
    void Start()
    {
        BGM_source.clip = Def_BGM;
        BGM_source.Play();
        _BGM_volume = BGM_source.volume;
    }

 
    public void Set_SPattack_BGM(AudioClip _SPattack_BGM)
    {
        SPattack_BGM = _SPattack_BGM;
    }

    public void Change_BGM_SP(bool flg)
    {
        _BGM_volume = BGM_source.volume;
        if (flg)
        {
            BGM_source.Stop();
            BGM_source.clip = SPattack_BGM;
            BGM_source.Play();
            BGM_source.volume = _BGM_volume;
        }
        else if (!flg)
        {
            BGM_source.Stop();
            BGM_source.clip = Def_BGM;
            BGM_source.Play();
            BGM_source.volume = _BGM_volume;
        }
    }

    public void Change_BGM_Win(bool flg)
    {
        _BGM_volume = BGM_source.volume;
        if (flg)
        {
            BGM_source.Stop();
            BGM_source.clip = Win_BGM;
            BGM_source.Play();
            BGM_source.volume = _BGM_volume;
        }
        else if (!flg)
        {
            BGM_source.Stop();
            BGM_source.clip = Def_BGM;
            BGM_source.Play();
            BGM_source.volume = _BGM_volume;
        }
    }

    public void Change_BGM_Lose(bool flg)
    {
        _BGM_volume = BGM_source.volume;
        if (flg)
        {
            BGM_source.Stop();
            BGM_source.clip = Lose_BGM;
            BGM_source.Play();
            BGM_source.volume = _BGM_volume;
        }
        else if (!flg)
        {
            BGM_source.Stop();
            BGM_source.clip = Def_BGM;
            BGM_source.Play();
            BGM_source.volume = _BGM_volume;
        }
    }
}
