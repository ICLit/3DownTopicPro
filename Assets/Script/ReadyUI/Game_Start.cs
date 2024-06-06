using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Game_Start : MonoBehaviour
{
    //public bool ready1, ready2, ready3, ready4;
    public Ready_Controllor player1, player2, player3, player4;

    private void Start()
    {
        player1.isReady = player2.isReady = player3.isReady = player4.isReady = false;
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void Update()
    {
        if (player1.isReady && player2.isReady && player3.isReady && player4.isReady)
        {
            LoadScene("SampleScene");
        }
    }
   /* public void ReadyState(int teamNumber)
    {
        switch (teamNumber)
        {
            case 1:
                ready1 = !ready1;
                break;
            case 2:
                ready2 = !ready2;
                break;
            case 3:
                ready3 = !ready3;
                break;
            case 4:
                ready4 = !ready4;
                break;
            default:
                Debug.LogError("Invalid team number!");
                break;
        }
    }*/
}
