using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_move_EF : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem Move_start_smoke1;
    [SerializeField]
    private ParticleSystem Move_start_smoke2;
    [SerializeField]
    private ParticleSystem Move_smoke1;
    [SerializeField]
    private ParticleSystem Move_smoke2;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move_start_somoke(bool boo)
    {
        Move_start_smoke1.Play();
        Move_start_smoke2.Play();

        if (boo)
        {
            Move_smoke1.Play();
            Move_smoke2.Play();
        }
        else if (!boo)
        {
            Move_smoke1.Stop();
            Move_smoke2.Stop();
        }
    }
}
