using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pile_driver : MonoBehaviour
{
    public GameObject _pile_driver_Attack; //打樁機攻擊prefab物件
    public void Attack(GameObject player, int teamNum)
    {
        Player _player = player.GetComponent<Player>();
        GameObject Mining_area_under_the_player = _player.player_Location._thisMining_area; //獲取玩家腳下的礦區

        if (_player.isOverheat)
        {
            Debug.Log(player + "的鑿破錘過熱中，無法使用");
            return;
        }

        if (Mining_area_under_the_player != null) //如果玩家腳下的礦區不為空
        {
            GameObject p_attack = Instantiate(_pile_driver_Attack, Mining_area_under_the_player.transform.position, player.transform.rotation); //生成打樁機攻擊物件
            Attack_Instantiate attack = p_attack.GetComponent<Attack_Instantiate>();
            attack.Attack_TeamNum = teamNum; //將攻擊物件的隊伍填進Attack_Instantiate
            attack.setTeamNum();
            _player.overheat_value += 0.25f;
        }
    }
}
