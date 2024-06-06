using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ready_Controllor : MonoBehaviour
{
    public GameObject readyButton;
    public Player_ScriptableObject player_Data;
    public Game_Start game_Start;

    public bool isReady;
    void Start()
    {
        isReady = false;

        player_Data.Player_Data.equipment = Player_Controller.Equipment.drill;
        player_Data.Player_Data.props = Player_Controller.Props.shield;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Ready()
    {
        isReady = !isReady;
        ReadyButtonUpdate();
    }

    public void ReadyButtonUpdate()
    {
        readyButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = isReady ? "Ready!!" : "Ready?";
    }

    public void SetEquipment(int equipNum)
    {
        player_Data.Player_Data.equipment = (Player_Controller.Equipment)equipNum;
    }

    public void SetProp(int propNum)
    {
        player_Data.Player_Data.props = (Player_Controller.Props)propNum;
    }
}
