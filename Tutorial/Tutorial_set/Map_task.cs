using UnityEngine;

public class Map_task : Tutorial
{

    //Move_task の情報を保持

    private string Task_title = "MAP";

    private string _Task_text = "Push Key \n  M";

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
        if (Input.GetKeyDown(KeyCode.M))
        {
            return true;
        }
        return false;
    }

    public void Dest_enemy() { }

}
