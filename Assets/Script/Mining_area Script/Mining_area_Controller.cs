using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining_area_Controller : MonoBehaviour
{
    public Material _material_0, _material_1, _material_2, _material_3, _material_4;
    [SerializeField]
    //private Occupy_information occupy_information;
    public TeamStatic teamStatic;

    private void Start()
    {
        //盢烩戈癟钉ヮ篈эΘNobody
        teamStatic = TeamStatic.Nobody;     
    }
    private void Update()
    {
        
    }

    public void Occupied(int teamNo)
    {
        switch (teamNo)
        {
            case 1:
                //Mining_area_Occupied.Occupied(gameObject, _material_1);
                teamStatic = TeamStatic.Team1;
                break;
            case 2:
                //Mining_area_Occupied.Occupied(gameObject, _material_2);
                teamStatic = TeamStatic.Team2;
                break;
            case 3:
                teamStatic = TeamStatic.Team3;
                break;
            case 4:
                teamStatic = TeamStatic.Team4;
                break;
            default://常ぃ才ǐ硂
                Debug.Log("Default case");
                break;
        }
        MiningArea_Update();
    }

    private void MiningArea_Update()
    {
        switch (teamStatic)
        {
            case TeamStatic.Team1:
                Mining_area_Occupied.Occupied(gameObject, _material_1);
                break;
            case TeamStatic.Team2:
                Mining_area_Occupied.Occupied(gameObject, _material_2);
                break;
            case TeamStatic.Team3:
                Mining_area_Occupied.Occupied(gameObject, _material_3);
                break;
            case TeamStatic.Team4:
                Mining_area_Occupied.Occupied(gameObject, _material_4);
                break;
            default://常ぃ才ǐ硂
                Debug.Log("Default case");
                break;
        }
    }


    public enum TeamStatic //钉ヮ篈
    {
        Nobody = 0,
        Team1 = 1,
        Team2 = 2,
        Team3 = 3,
        Team4 = 4,
    }
}



