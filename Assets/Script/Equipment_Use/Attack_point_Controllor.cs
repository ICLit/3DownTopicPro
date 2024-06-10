using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_point_Controllor : MonoBehaviour
{
    public int TeamNum = 0;
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player")) //如果碰到Player
        {
            Player player = other.GetComponent<Player>();
            if (!(player._myTeam.GetHashCode() == TeamNum) && !(TeamNum == 0)) //如果Player的隊伍編號不等於此攻擊的隊伍編號且不為0
            {
                Debug.Log($"{other.gameObject.name} 死於 玩家{TeamNum}");
                player.Dead();
            }
        }

        if (other.GetComponent<Box>() != null)
        {
            Debug.Log("攻擊箱子");

            Box box = other.GetComponent<Box>();
            box.DestroyThisBox();
        }
    }
}
