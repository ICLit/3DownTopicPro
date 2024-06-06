using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game_Controller : MonoBehaviour
{
    public GameObject[] allMining_area;
    //public TextMeshProUGUI Team1_Score, Team2_Score, Team3_Score, Team4_Score, Win_Text; //UI��ܤ��� & �ӧQ��r
    //public Image Team1_Scorebar, Team2_Scorebar, Team3_Scorebar, Team4_Scorebar;
    int occupyNum_team1 = 0, occupyNum_team2 = 0, occupyNum_team3 = 0, occupyNum_team4 = 0; //���⪺��a��
    public float team1 = 0, team2 = 0, team3 = 0, team4 = 0; //�`��
    float score_Calculate_Timer = 0;
    internal float winScore = 3000; //�ӧQ�ؼФ�
    void Start()
    {
        allMining_area = GameObject.FindGameObjectsWithTag("Mining_area"); // �N�Ҧ��q�ϥ[�J�}�C
        //allMining_area.Add(GameObject.FindGameObjectsWithTag("Mining_area"));
    }

    void Update()
    {
        //Occupy_Calculate();
        Score_Update();
    }
    private void Score_Update() //�O���O��s
    {
        Occupy_Calculate();
        Score_Calculate();
    }
    private void Occupy_Calculate() //�p����W����a��
    {
        occupyNum_team1 = 0; occupyNum_team2 = 0; occupyNum_team3 = 0; occupyNum_team4 = 0;
        foreach (GameObject g in allMining_area)
        {
            Mining_area_Controller mining_Area_Controller = g.GetComponent<Mining_area_Controller>();
            var teamStatic = mining_Area_Controller.teamStatic.ToString();
            switch (teamStatic)
            {
                case "Team1":
                    occupyNum_team1++;
                    break;
                case "Team2":
                    occupyNum_team2++;
                    break;
                case "Team3":
                    occupyNum_team3++;
                    break;
                case "Team4":
                    occupyNum_team4++;
                    break;
            }
        }
    }
    private void Score_Calculate() //�p�����
    {
        if (score_Calculate_Timer > 1) //�p�G�C���ɶ��O���(�L�F�@��)
        {
            team1 += occupyNum_team1; //���ƥ[�W���⪺��a��
            team2 += occupyNum_team2;
            team3 += occupyNum_team3;
            team4 += occupyNum_team4;
            score_Calculate_Timer = 0; //�p���k�s
        }
        score_Calculate_Timer += Time.deltaTime;
    }

    private void Is_Victory() //�ӧQ�P�w
    {

    }

    public enum Team
    {
        Nobody = 0,
        Team1 = 1,
        Team2 = 2,
        Team3 = 3,
        Team4 = 4,
    }
}
