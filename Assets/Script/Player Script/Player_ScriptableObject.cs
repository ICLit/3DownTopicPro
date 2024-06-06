using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new player", menuName = "ScriptableObject/Player Data Asset")]
public class Player_ScriptableObject : ScriptableObject
{
    public Data Player_Data;
}

[System.Serializable]
public class Data
{
    public Player_Controller.MyTeam team;
    public Player_Controller.Equipment equipment;
    public Player_Controller.Props props;
}
