using UnityEngine;

public class Zoom_task : Tutorial
{

    //Move_task の情報を保持

    private string Task_title = "Zoom";

    private string _Task_text = "Hold down\nMouse Right";

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
        if (Input.GetMouseButtonDown(1)) 
        {
            return true;
        }
        return false;
    }

    public void Dest_enemy() { }

}
