using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pile_driver : MonoBehaviour
{
    public GameObject _pile_driver_Attack; //���ξ�����prefab����
    public void Attack(GameObject player, int teamNum)
    {
        Player _player = player.GetComponent<Player>();
        GameObject Mining_area_under_the_player = _player.player_Location._thisMining_area; //������a�}�U���q��

        if (_player.isOverheat)
        {
            Debug.Log(player + "���w�}��L�����A�L�k�ϥ�");
            return;
        }

        if (Mining_area_under_the_player != null) //�p�G���a�}�U���q�Ϥ�����
        {
            GameObject p_attack = Instantiate(_pile_driver_Attack, Mining_area_under_the_player.transform.position, player.transform.rotation); //�ͦ����ξ���������
            Attack_Instantiate attack = p_attack.GetComponent<Attack_Instantiate>();
            attack.Attack_TeamNum = teamNum; //�N�������󪺶����iAttack_Instantiate
            attack.setTeamNum();
            _player.overheat_value += 0.25f;
        }
    }
}
