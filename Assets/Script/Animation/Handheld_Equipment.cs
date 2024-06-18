using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;



public class Handheld_Equipment : MonoBehaviour
{
    public GameObject[] equimentPrefab = new GameObject[3];
    public Player player;
    public GameObject handheld_Transform; //�ҫ��W�������m

    void Start()
    {
        //EquipmentJudge();
    }

    public void Handheld(int equimentNum)
    {
        GameObject equiment = Instantiate(equimentPrefab[equimentNum - 1]);
        ParentConstraint parentConstraint = equiment.GetComponent<ParentConstraint>();

        //�NGameobject��Ƭ�ConstraintSource���
        ConstraintSource constraintSource = new ConstraintSource
        {
            //sourceTransform = equimentPrefab[equimentNum - 1].transform,
            sourceTransform = handheld_Transform.transform,
            weight = 1.0f
        };

        parentConstraint.AddSource(constraintSource);

        parentConstraint.constraintActive = true;
    }

    public void EquipmentJudge() //�P�_�Z��
    {
        switch (player._equipment)
        {
            case Player_Controller.Equipment.drill://�p�Y
                Handheld(1);
                break;
            case Player_Controller.Equipment.pile_driver://���ξ�
                Handheld(2);
                break;
            case Player_Controller.Equipment.demolition_hamer://�w�}��
                Handheld(3);
                break;
            default://�H�W�����ŦX���o��
                Debug.LogError("Handheld_Equment �� EquipmentJude �X�� ");
                break;
        }
    }
}
