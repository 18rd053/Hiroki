using UnityEngine;

using UnityEngine.UI;
public class Tutorial_item : MonoBehaviour
{
    //チュートリアル用のアイテム生成

    //アイテム生成場所
    private Vector3 Item_pos1 = new Vector3(200f, 20f, 200f);
    private Vector3 Item_pos2 = new Vector3(1800f, 20f, 200f);

    [SerializeField]
    private GameObject Repair;
    [SerializeField]
    private GameObject SPball;


    //説明文を出すようのアイテム状態保持
    private GameObject _Repair;
    private GameObject _SPball;
    private bool Item_flg = false;

    //アイテム説明
    [SerializeField]
    private GameObject Item_ex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Item_flg && (!_Repair || !_SPball))
        {
            Time.timeScale = 0f;
            Item_ex.SetActive(true);
            var Can = Item_ex.transform.parent.GetComponent<Canvas>();
            Can.GetComponent<RectTransform>().SetAsFirstSibling();
            Cursor.lockState = CursorLockMode.None;
        }
   
    }

    public void Item_panel_off()
    {
        Time.timeScale = 1f;
        Item_ex.SetActive(false);
        Item_flg = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Item_create()
    {
        
        _Repair = Instantiate(Repair, Item_pos1, Quaternion.identity);
        _SPball = Instantiate(SPball, Item_pos2, Quaternion.identity);
        Item_flg = true;
    }
}
