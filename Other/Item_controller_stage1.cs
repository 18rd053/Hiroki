using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_controller_stage1 : MonoBehaviour
{

    //アイテムを生成する場所
    private Vector3 Item_pos1 = new Vector3 (1100f,20f,900f);
    

    //アイテムを生成するタイミング
    [SerializeField]
    private float _timer;

    //初期状態は10秒に１度生成するかのランダムを行う
    [SerializeField]
    private float _Create_time = 20;

    //生成される確率

    //生成するアイテム
    [SerializeField]
    private GameObject Repair;
    [SerializeField]
    private GameObject SPball;

    //生成したアイテム
    private GameObject Item = null;


    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _Create_time) Create_item();
    }

    //今回はSPballのみ
    private void Create_item()
    {
        _timer = 0;
        //5分の1でアイテムを生成
        if(Random.Range(1,6) == 5)
        {
            if(Item == null)
            {
                Item = Instantiate(SPball, Item_pos1, Quaternion.identity);
            }
        }
    }
}
