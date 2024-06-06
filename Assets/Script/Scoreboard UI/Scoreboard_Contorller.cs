using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scoreboard_Contorller : MonoBehaviour
{
    public Player_ScriptableObject Player_Data;
    public Player player;
    public Game_Controller.Team this_team;
    public float teamScore;

    [Header("UI物件")]
    public TextMeshProUGUI Score_text;
    public Image Score_bar;
    public Image Equip_Image, Prop_Image;
    public GameObject OverhearText; //過熱Error文字
    public Image OverHeat_Meter;
    public Game_Controller game_Controller;
    public EquipAndProps_Image AllImages; //裝備&道具的圖片

    private void Start()
    {
        if (game_Controller == null)
        {
            game_Controller = FindObjectOfType<Game_Controller>();
        }
        if (game_Controller == null)
        {
            Debug.LogError("Game_Controller is not assigned and could not be found in the scene.");
        }
    }
    private void Update()
    {
        ScoreUpdate();
        EquipImageUpdate();
        PropsImageUpdate();
        OverHeat_Meter_Update();
    }

    public void SetTeamScore()
    {
        switch (this_team)
        {
            case Game_Controller.Team.Team1:
                teamScore = game_Controller.team1;
                break;
            case Game_Controller.Team.Team2:
                teamScore = game_Controller.team2;
                break;
            case Game_Controller.Team.Team3:
                teamScore = game_Controller.team3;
                break;
            case Game_Controller.Team.Team4:
                teamScore = game_Controller.team4;
                break;
            default:
                Debug.LogError("記分板隊伍資訊設定錯誤");
                break;
        }
    }

    public void ScoreUpdate()
    {
        SetTeamScore();
        Score_text.text = Mathf.FloorToInt(teamScore).ToString();
        Score_bar.fillAmount = teamScore / game_Controller.winScore;
    }

    public void OverHeat_Meter_Update()
    {
        if (player == null)
        {
            return;
        }

        OverhearText.SetActive(player.isOverheat);
        OverHeat_Meter.fillAmount = player.overheat_value;
    }

    public void EquipImageUpdate() //更新裝備圖示UI
    {
        if (player == null)
        {
            return;
        }
        switch (player._equipment)
        {
            case Player_Controller.Equipment.no_have_equipment:
                Equip_Image.sprite = AllImages.Equip.equipImage[0];
                break;
            case Player_Controller.Equipment.drill:
                Equip_Image.sprite = AllImages.Equip.equipImage[1];
                break;
            case Player_Controller.Equipment.pile_driver:
                Equip_Image.sprite = AllImages.Equip.equipImage[2];
                break;
            case Player_Controller.Equipment.demolition_hamer:
                Equip_Image.sprite = AllImages.Equip.equipImage[3];
                break;
            default://以上都不符合走這個
                Debug.LogError("計分表裝備切換出錯");
                break;
        }
    }

    public void PropsImageUpdate() //更新道具圖示UI
    {
        if (player == null)
        {
            Debug.Log(player + "為NULL");
            return;
        }
        switch (player._props)
        {
            case Player_Controller.Props.no_have_props:
                Prop_Image.sprite = AllImages.Props.propsImage[0];
                break;
            case Player_Controller.Props.shield:
                Prop_Image.sprite = AllImages.Props.propsImage[1];
                break;
            case Player_Controller.Props.speed:
                Prop_Image.sprite = AllImages.Props.propsImage[2];
                break;
            case Player_Controller.Props.brick:
                Prop_Image.sprite = AllImages.Props.propsImage[3];
                break;
            case Player_Controller.Props.boom:
                Prop_Image.sprite = AllImages.Props.propsImage[4];
                break;
            case Player_Controller.Props.mines:
                Prop_Image.sprite = AllImages.Props.propsImage[5];
                break;
            case Player_Controller.Props.hook:
                Prop_Image.sprite = AllImages.Props.propsImage[6];
                break;
            default://以上都不符合走這個
                Debug.LogError("計分表道具切換出錯");
                break;
        }
    }
}
