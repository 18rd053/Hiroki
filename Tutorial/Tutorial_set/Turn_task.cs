using UnityEngine;

public class Turn_task : Tutorial
{

    //Move_task の情報を保持

    private string Task_title = "TURN";

    private string _Task_text = "Push Key\nA-LeftTurn\nD-RightTurn";

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
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            return true;
        }
        return false;
    }

    public void Dest_enemy() { }

}
