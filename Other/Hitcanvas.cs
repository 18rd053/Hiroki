using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitcanvas : MonoBehaviour
{
    [SerializeField]
    private Animator Hit_panel;

    private AudioSource SE;

    [SerializeField]
    private AudioClip _hit_SE;

    // Start is called before the first frame update
    void Start()
    {
        SE = GameObject.FindWithTag("SE").GetComponent<AudioSource>();
        SE.PlayOneShot(_hit_SE);
    }

    // Update is called once per frame
    void Update()
    {
        if (Hit_panel.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9)
        {
            Destroy(this.gameObject);
        }
    }
}
