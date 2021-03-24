using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Tank_spec : ScriptableObject{

    public List<Tank_Status> Tank_StatusList = new List<Tank_Status>();

}

[System.Serializable]
public class Tank_Status
{
    public string Name = "Cromwell";
    public int HP = 100;
    public float Move_speed = 4000f, Move_speed_limit = 35f, Tank_downforce = 3000;
    public Vector3 Move_rotate = new Vector3(0, -1f, 0);
}