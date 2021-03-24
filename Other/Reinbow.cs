using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reinbow : MonoBehaviour
{
    [SerializeField]
    private float _time;

    [SerializeField]
    float HSV_color;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        HSV_color = _time * 0.1f * 2f;
        GetComponent<Renderer>().material.color = Color.HSVToRGB(HSV_color, 1, 1);
        if (_time >= 5) _time = 0 ;

    }
   
}
