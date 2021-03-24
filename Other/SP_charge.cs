using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_charge : MonoBehaviour
{


    //全体のボリューム管理と同じボリュームにするため
    [SerializeField]
    private AudioSource SE;
    [SerializeField]
    private AudioSource SE_SP_charge;


    [SerializeField]
    private AudioClip SE_SP_charge_clip;

    // Start is called before the first frame update
    void Start()
    {
        SE_SP_charge.volume = SE.volume * 0.5f;

        SE_SP_charge.clip = SE_SP_charge_clip;

        SE_SP_charge.Play();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
