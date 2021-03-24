using UnityEngine;

public class Shot_task : Tutorial
{

    //Move_task の情報を保持

    private string Task_title = "SHOT";

    private string _Task_text = "Push Mouse\nLeftButton";

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
        if (Input.GetMouseButtonDown(0))
        {
            return true;
        }
        return false;
    }

    public void Dest_enemy() { }

}
