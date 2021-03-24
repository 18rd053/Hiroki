using UnityEngine;

public class Fight_task : Tutorial
{
    //Fight_task の情報を保持

    private string Task_title = "Fight";

    private string _Task_text = "Destruction\n 3　Enemy";

    public int _Dest_enemy = 0;

    public string Set_title()
    {
        return Task_title;
    }

    public string Set_text()
    {
        return _Task_text;
    }

    public bool Check_task()
    {
        if (_Dest_enemy >= 3)
        {
            return true;
        }
        return false;
   
    }

    public void Dest_enemy()
    {
        _Dest_enemy++;
    }
}
