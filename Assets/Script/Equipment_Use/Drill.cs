using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour
{
    public bool is_Drill_attack = false;
    public GameObject _drill_Attack_Collider; //鑽頭攻擊碰撞箱
    public Player player;
    Attack_point_Controllor _atk_Controllor; //攻擊控制腳本

    private void Start()
    {
        _atk_Controllor = _drill_Attack_Collider.GetComponent<Attack_point_Controllor>();
    }
    public void Attack()
    {

        if (is_Drill_attack == false) //將is_Drill_attack打開
        {
            OpenDrillAttack();
        }
        else
        {
            CloseDrillAttack();
        }
    }
    private void Update()
    {
        if (player.isOverheat == true && player._equipment == Player_Controller.Equipment.drill)
        {
            Debug.Log(player + "的鑽頭過熱中");
            CloseDrillAttack();
        }

        if (is_Drill_attack == true)
        {
            _drill_Attack_Collider.SetActive(true); //打開攻擊判定點
            _atk_Controllor.TeamNum = player._myTeam.GetHashCode();

            player.overheat_value += 0.4f * Time.deltaTime;
        }
        else
        {
            _drill_Attack_Collider.SetActive(false); //關閉攻擊判定點
        }
    }

    void OpenDrillAttack()
    {
        is_Drill_attack = true;
        player.speed += 3;
    }
    void CloseDrillAttack()
    {
        if (is_Drill_attack == true)
        {
            is_Drill_attack = false;
            player.speed -= 3;
        }
    }
}
