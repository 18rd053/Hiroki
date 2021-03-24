
using UnityEngine;

public class Success_task : Tutorial
{
    //Fight_task の情報を保持

    //private string Task_title = "Great";

    //private string _Task_text = "Completed　\n ALL Task!";


    private string Task_title = "";

    private string _Task_text = "";

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
        return false;
    }

    public void Dest_enemy() { }
}
