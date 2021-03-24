using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Shot : MonoBehaviour
{
    //砲身の空オブジェクトに取り付けるスクリプト 、弾の生成、リロード表示を行う。
    Vector3 Now_pos;
    public GameObject bullet;

    public float Bullet_time = 0f;
    public float Cool_time = 3f;

    [SerializeField]
    private Slider Reload_bar;
    [SerializeField]
    private Image _Reload_color;

    private bool _Reload_flg = false;

    private Charactor_voice Cv;

    // Start is called before the first frame update
    void Start()
    {
        //親（タンク本体)のスクリプトを参照
        Cv = transform.root.gameObject.GetComponent<Charactor_voice>();

        ///リロード時間を設定
        Reload_bar.maxValue = Cool_time;
        Bullet_time = 3.0f;
    }
    private void Update()
    {
        if (Cool_time >= Bullet_time)
        {
            Bullet_time += Time.deltaTime;
            Reload_bar.value = Bullet_time;
        }
        if(Cool_time <= Bullet_time)
        {
            if (!_Reload_flg) Reload_max();
            if (Input.GetKey(KeyCode.Return)) Create_bullet();
          
        }
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        

    }

    void Create_bullet() {
        Now_pos = this.transform.position;
        Bullet_time = 0f;
        _Reload_flg = false;
        _Reload_color.color = new Color32(255, 255, 0, 255);
        //GameObject Bullet_pre =
        Instantiate(bullet, Now_pos, transform.rotation);

    }

    void Reload_max()
    {
        _Reload_flg = true;
        _Reload_color.color = new Color32(0,255,0,255);
    }


}
