using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactor_voice : MonoBehaviour
{
    [SerializeField]
    private AudioClip Attack_1;

    [SerializeField]
    private AudioClip Attack_2;

    [SerializeField]
    private AudioClip Damage_1;

    [SerializeField]
    private AudioClip Damage_2;

    [SerializeField]
    private AudioClip SPattack_voice;

    [SerializeField]
    private AudioClip Win;

    [SerializeField]
    private AudioClip Lose;

    [SerializeField]
    private AudioSource Character_audio;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        int Anum = Random.Range(1, 3);
        if (Anum == 1) Character_audio.PlayOneShot(Attack_1);
        else if (Anum == 2) Character_audio.PlayOneShot(Attack_2);
    }

    public void Damage()
    {
        int Dnum = Random.Range(1, 3);
        if (Dnum == 1) Character_audio.PlayOneShot(Damage_1);
        else if (Dnum == 2) Character_audio.PlayOneShot(Damage_2);
    }

    public void _SPattack()
    {
        Character_audio.PlayOneShot(SPattack_voice);
    }

    public void Win_voice()
    {
        Character_audio.PlayOneShot(Win);
    }

    public void Lose_voice()
    {
        Character_audio.PlayOneShot(Lose,Character_audio.volume * 1.2f);
    }

}
