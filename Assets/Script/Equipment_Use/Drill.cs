using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour
{
    public bool is_Drill_attack = false;
    public GameObject _drill_Attack_Collider; //�p�Y�����I���c
    public Player player;
    Attack_point_Controllor _atk_Controllor; //��������}��

    private void Start()
    {
        _atk_Controllor = _drill_Attack_Collider.GetComponent<Attack_point_Controllor>();
    }
    public void Attack()
    {

        if (is_Drill_attack == false) //�Nis_Drill_attack���}
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
            Debug.Log(player + "���p�Y�L����");
            CloseDrillAttack();
        }

        if (is_Drill_attack == true)
        {
            _drill_Attack_Collider.SetActive(true); //���}�����P�w�I
            _atk_Controllor.TeamNum = player._myTeam.GetHashCode();

            player.overheat_value += 0.4f * Time.deltaTime;
        }
        else
        {
            _drill_Attack_Collider.SetActive(false); //���������P�w�I
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
