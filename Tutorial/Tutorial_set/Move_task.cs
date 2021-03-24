using UnityEngine;

public class Move_task : Tutorial
{

    //Move_task の情報を保持

    private string Task_title = "MOVE";

    private string _Task_text = "Push Key\nW-Foward\nS-Back";

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
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            return true;
        }
        return false;
    }

    public void Dest_enemy() { }

}
