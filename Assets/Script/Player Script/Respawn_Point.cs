using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn_Point : MonoBehaviour
{
    public Player _player;
    public Player_ScriptableObject playerData;
    public Scoreboard_Contorller scoreboard_Contorller;
    void Start()
    {
        PlayerInstantiate();
    }

    // Update is called once per frame
    public void PlayerInstantiate()
    {
        Player player = Instantiate(_player, gameObject.transform.position, Quaternion.identity);
        player._equipment = playerData.Player_Data.equipment;
        player._props = playerData.Player_Data.props;
        scoreboard_Contorller.player = player;
    }
}
