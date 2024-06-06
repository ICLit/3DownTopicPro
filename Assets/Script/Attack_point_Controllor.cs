using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_point_Controllor : MonoBehaviour
{
    public int TeamNum = 0;
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player")) //�p�G�I��Player
        {
            Player player = other.GetComponent<Player>();
            if (!(player._myTeam.GetHashCode() == TeamNum) && !(TeamNum == 0)) //�p�GPlayer������s�������󦹧���������s���B����0
            {
                Debug.Log($"{other.gameObject.name} ���� ���a{TeamNum}");
                player.Dead();
            }
        }

        if (other.GetComponent<Box>() != null)
        {
            Debug.Log("�����c�l");

            Box box = other.GetComponent<Box>();
            box.DestroyThisBox();
        }
    }
}
