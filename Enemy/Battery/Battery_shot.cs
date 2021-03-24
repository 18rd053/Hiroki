using System.Collections;
using System.Collections.Generic;
using Audio_keeper;
using UnityEngine;

public class Battery_shot : MonoBehaviour
{
    /// <summary>
    /// 各敵砲台のGun_posに取り付け射撃を管理
    /// BulletとSearchが見えている
    /// </summary>
    private float Bullet_reload_time;
    private int Bullet_attack_point;
    //砲台によって弾の大きさを変える
    private int Bullet_size;
    ///

    public GameObject Bullet;


    private float Now_reload;


    /// <summary>
    /// 音
    /// </summary>
    [SerializeField]
    private AudioSource Enemy_SE;

    //全体のSEを管理から音量をもらう
    private Audio_managerData _Audio_managerData;

    [SerializeField]
    private AudioClip Shot_SE;



    [SerializeField]
    private Search_player _Search_player;

    private void Awake()
    {
        _Audio_managerData = FindObjectOfType<Audio_manager>().Get_AudioManagerData();
        Enemy_SE.volume = _Audio_managerData.Get_SEVolume();
    }

    void FixedUpdate()
    {
        if(Bullet_reload_time > Now_reload)
        {
            Now_reload += Time.deltaTime;
        }else if (Bullet_reload_time <= Now_reload && _Search_player.Player_flg)
        {
            Shot();
        }
    }

    private void Shot()
    {
        Now_reload = 0;
        var _Bullet = Instantiate(Bullet, transform.position, transform.rotation);
        _Bullet.GetComponent<Battery_bullet>().Set_bullet_data(Bullet_attack_point, Bullet_size);

        Enemy_SE.volume = _Audio_managerData.Get_SEVolume();
        Enemy_SE.PlayOneShot(Shot_SE);
    }

    public void Set_shot(float _Bullet_reload_time , int _Bullet_attack_point ,
        int _Bullet_size)
    {
        Bullet_reload_time = _Bullet_reload_time;
        Bullet_attack_point = _Bullet_attack_point;
        Bullet_size = _Bullet_size;
    }
}
