using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_move_sound : MonoBehaviour
{
    [SerializeField]
    private AudioClip _Shot_start;

    [SerializeField]
    private AudioClip _Tank_move;

    [SerializeField]
    private AudioClip _SPattack;

    [SerializeField]
    private AudioClip _SPBall_get;

    [SerializeField]
    private AudioClip _Smoke;

    [SerializeField]
    private AudioClip _Heal;

    [SerializeField]
    private AudioClip _Lose_ex;

    [SerializeField]
    private AudioClip _Change_camera;

    [SerializeField]
    private AudioClip _Map;

    [SerializeField]
    private AudioSource SE;


    private void Awake()
    {
        SE = GameObject.FindWithTag("SE").GetComponent<AudioSource>();
    }

    public void Tank_move(bool Flg)
    {
        
        if (Flg)
        {
            if (!SE.loop) SE.loop = true;
            //SE.PlayOneShot(_Tank_move);
            SE.clip = _Tank_move;
            SE.Play();
        }
        else if (!Flg)
        {
            if (SE.loop) SE.loop = false;
            SE.Stop();
        }
    }

    public void Shot_start()
    {
        //if (SE.loop) SE.loop = !SE.loop;
        SE.PlayOneShot(_Shot_start);
    }

    public void Smoke()
    {
        //if (SE.loop) SE.loop = !SE.loop;
        //SE.PlayOneShot(_Smoke);
        AudioSource.PlayClipAtPoint(_Smoke , transform.position ,SE.volume);
    }
        
    public void Lose_SE()
    {
        SE.PlayOneShot(_Lose_ex);
    }

    public void Heal()
    {
        SE.PlayOneShot(_Heal);
    }

    public void SPattack()
    {
        SE.PlayOneShot(_SPattack);
    }

    public void SPball_get()
    {
        SE.PlayOneShot(_SPBall_get);
    }

    public void Change_camera()
    {
        SE.PlayOneShot(_Change_camera);
    }

    public void Map()
    {
        SE.PlayOneShot(_Map);
    }

}
