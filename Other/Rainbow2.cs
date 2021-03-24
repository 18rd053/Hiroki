using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rainbow2 : MonoBehaviour
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
    /*
    //色が変わるタイミング(時間)を「Cube」のInspector(Duration)で指定、初期値は1.0F
    public float duration = 1.0F;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //durationの時間ごとに色が変わる
        float phi = Time.time / duration * 2 * Mathf.PI;
        float amplitude = Mathf.Cos(phi) * 0.5F + 0.5F;
        //色をRGBではなくHSVで指定
        GetComponent<Renderer>().material.color = Color.HSVToRGB(amplitude, 1, 1);

    }
    */
}
