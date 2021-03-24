using Audio_keeper;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_tank_shot : MonoBehaviour
{
    //敵戦車の射撃を管理Gun_posに取り付ける
    //敵戦車のメインスクリプト から必要情報を受け取り弾丸に渡す。
    
    [SerializeField]
    private Bullet_enemy_tank _Bullet_enemy_tank;

    private float Bullet_reload_time;
    private int Bullet_attack_point;



    private float Now_reload = 0;
    private bool Rock_on = false;

    /// <summary>
    /// 音
    /// </summary>
    [SerializeField]
    private AudioSource Enemy_SE;

    [SerializeField]
    private AudioClip Shot_SE;

    //全体のSE管理から音量をもらう
    private Audio_managerData _Audio_managerData;


    private void Awake()
    {
        _Audio_managerData = FindObjectOfType<Audio_manager>().Get_AudioManagerData();
        Enemy_SE.volume = _Audio_managerData.Get_SEVolume();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Bullet_reload_time >= Now_reload)
        {
            Now_reload += Time.deltaTime;
        }
        else if (Rock_on && Bullet_reload_time < Now_reload)
        {
            Now_reload = 0;
            Shot_bullet();
        }
    }

    private void Shot_bullet()
    {
        var Ene_bullet = Instantiate(_Bullet_enemy_tank, transform.position, transform.rotation);
        Ene_bullet.Set_attack_point(Bullet_attack_point);

        Enemy_SE.volume = _Audio_managerData.Get_SEVolume();
        Enemy_SE.PlayOneShot(Shot_SE);
    }

    public void Set_shot(float _Bullet_reload_time, int _Bullet_attack_point)
    {
        Bullet_reload_time = _Bullet_reload_time;
        Bullet_attack_point = _Bullet_attack_point;
    }

    //プレイヤー発見
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) Rock_on = true;
    }

    //プレイヤーを見失う
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) Rock_on = false;
    }
}
