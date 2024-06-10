using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game_Controller : MonoBehaviour
{
    public GameObject[] allMining_area;
    int occupyNum_team1 = 0, occupyNum_team2 = 0, occupyNum_team3 = 0, occupyNum_team4 = 0; //佔領的領地數
    public float team1 = 0, team2 = 0, team3 = 0, team4 = 0; //總分
    float score_Calculate_Timer = 0;
    internal float winScore = 3000; //勝利目標分 3000

    public Winner_UI winner_UI;
    bool isSomeoneWin; //有人贏了
    void Start()
    {
        allMining_area = GameObject.FindGameObjectsWithTag("Mining_area"); // 將所有礦區加入陣列
        //allMining_area.Add(GameObject.FindGameObjectsWithTag("Mining_area"));
    }

    void Update()
    {
        //Occupy_Calculate();
        Score_Update();
    }
    private void Score_Update() //記分板更新
    {
        Occupy_Calculate();
        Score_Calculate();
    }
    private void Occupy_Calculate() //計算場上的領地數
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
    private void Score_Calculate() //計算分數
    {
        if (score_Calculate_Timer > 1) //如果遊戲時間是整數(過了一秒)
        {
            team1 += occupyNum_team1; //分數加上佔領的領地數
            team2 += occupyNum_team2;
            team3 += occupyNum_team3;
            team4 += occupyNum_team4;
            score_Calculate_Timer = 0; //計時歸零
        }
        score_Calculate_Timer += Time.deltaTime;
        Is_Victory();//判定是否有人贏
    }

    private void Is_Victory() //勝利判定
    {
        if (winner_UI == null)
        {
            Debug.Log("winner_UI 為 null");
            return;
        }

        if (!isSomeoneWin) //當目前沒人贏
        {
            float[] teamScores = { team1, team2, team3, team4 };
            for (int i = 0; i < teamScores.Length; i++)
            {
                if (teamScores[i] > winScore)
                {
                    winner_UI.Winner(i + 1);
                    isSomeoneWin = true;
                    break;
                }
            }
        }
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
