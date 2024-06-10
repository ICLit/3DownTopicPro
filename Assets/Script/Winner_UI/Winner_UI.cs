using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Winner_UI : MonoBehaviour
{
    public GameObject WinnerPlane;
    public Image playerImageSet, Bg; //UI��Ϫ��a�� & �I��

    public TextMeshProUGUI winnerText1, winnerText2;
    public List<Sprite> playerImageList; //���a����Ϥ�
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
            Debug.LogError("�}��Winner_UI �� Winner �X���D");
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
