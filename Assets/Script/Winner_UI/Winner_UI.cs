using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Winner_UI : MonoBehaviour
{
    public GameObject WinnerPlane;
    public Image playerImageSet, Bg; //UI放圖的地方 & 背景

    public TextMeshProUGUI winnerText1, winnerText2;
    public List<Sprite> playerImageList; //玩家角色圖片
    public List<Color> playerColor;
    public List<Material> WinnerTextMtrl;

    void Start()
    {

    }

    // Update is called once per frame
    public void Winner(int winPlayer)
    {
        WinnerPlane.SetActive(true);

        if (winPlayer < 1 || winPlayer > 4)
        {
            Debug.LogError("腳本Winner_UI 的 Winner 出問題");
            return;
        }

        SetWinner(winPlayer);
    }

    void SetWinner(int playerIndex)
    {
        winnerText2.text = $"Player {playerIndex}";
        winnerText1.GetComponent<TextMeshProUGUI>().fontMaterial = WinnerTextMtrl[playerIndex - 1];
        winnerText2.GetComponent<TextMeshProUGUI>().fontMaterial = WinnerTextMtrl[playerIndex - 1];
        Bg.color = playerColor[playerIndex - 1];
        playerImageSet.sprite = playerImageList[playerIndex - 1];
    }
}
