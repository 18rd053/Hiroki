using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_sound : MonoBehaviour
{
    //bulletの音
    [SerializeField]
    private AudioClip _Bullet;

    [SerializeField]
    private AudioClip _Bullet_end;

    private AudioSource Bullet_audio;

    private AudioSource SE;

    // Start is called before the first frame update

    private void Awake()
    {
        Bullet_audio = GetComponent<AudioSource>();
        SE = GameObject.FindWithTag("SE").GetComponent<AudioSource>();
        Bullet_audio.volume = SE.volume;
        Bullet_audio.clip = _Bullet;
    }
    void Start()
    {
        Bullet_audio.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Bullet_end()
    {
        AudioSource.PlayClipAtPoint(_Bullet_end, transform.position,Bullet_audio.volume * 1.5f);
    }
}
