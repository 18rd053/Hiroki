using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killcanvas : MonoBehaviour
{
    [SerializeField]
    private Animator Kill_panel;

    private AudioSource SE;

    [SerializeField]
    private AudioClip _kill_SE;

    // Start is called before the first frame update
    void Start()
    {
        SE = GameObject.FindWithTag("SE").GetComponent<AudioSource>();
        SE.PlayOneShot(_kill_SE);
    }

    // Update is called once per frame
    void Update()
    {
        if (Kill_panel.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9)
        {
            Destroy(this.gameObject);
        }
    }
}
