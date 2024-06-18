using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;



public class Handheld_Equipment : MonoBehaviour
{
    public GameObject[] equimentPrefab = new GameObject[3];
    public Player player;
    public GameObject handheld_Transform; //模型上的手持位置

    void Start()
    {
        //EquipmentJudge();
    }

    public void Handheld(int equimentNum)
    {
        GameObject equiment = Instantiate(equimentPrefab[equimentNum - 1]);
        ParentConstraint parentConstraint = equiment.GetComponent<ParentConstraint>();

        //將Gameobject轉化為ConstraintSource單位
        ConstraintSource constraintSource = new ConstraintSource
        {
            //sourceTransform = equimentPrefab[equimentNum - 1].transform,
            sourceTransform = handheld_Transform.transform,
            weight = 1.0f
        };

        parentConstraint.AddSource(constraintSource);

        parentConstraint.constraintActive = true;
    }

    public void EquipmentJudge() //判斷武器
    {
        switch (player._equipment)
        {
            case Player_Controller.Equipment.drill://鑽頭
                Handheld(1);
                break;
            case Player_Controller.Equipment.pile_driver://打樁機
                Handheld(2);
                break;
            case Player_Controller.Equipment.demolition_hamer://鑿破機
                Handheld(3);
                break;
            default://以上都不符合走這個
                Debug.LogError("Handheld_Equment 的 EquipmentJude 出錯 ");
                break;
        }
    }
}
