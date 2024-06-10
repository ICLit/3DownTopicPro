using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Player_Controller.MyTeam _myTeam; //����
    public Player_Controller.Equipment _equipment; //�ثe�˳�
    public Player_Controller.Props _props; //�ثe�D��

    public float speed; //�t��
    public float overheat_value = 0; //�L����
    public bool isOverheat, isDizzy; //���b�L���A���b�w�t
    public bool haveShield; //�����@��

    public Player_Controller player_Controller;
    public Player_Location player_Location; //���a��e��m
    public string[] InputKey = new string[] { "e", "w", "a", "s", "d", "q" }; //���]�w

    void Start()
    {
        if (_myTeam == Player_Controller.MyTeam.Nobody)
        {
            _myTeam = Player_Controller.MyTeam.Team1;
        }
        if (_equipment == Player_Controller.Equipment.no_have_equipment)
        {
            _equipment = Player_Controller.Equipment.pile_driver;
        }
    }
    void FixedUpdate()
    {
        if (!isDizzy)
            player_Controller.PlayerMove(this.gameObject, InputKey); //���a����
        else
            player_Controller.animatorCtrl.Set_isRun(false);
    }
    private void Update()
    {
        if (!isDizzy)
        {
            if (Input.GetKeyDown(InputKey[0])) //���UE���ϥθ˳�
            {
                player_Controller.UseEquipment(this.gameObject);
            }
            if (Input.GetKeyDown(InputKey[5])) //���UQ���ϥθ˳�
            {
                player_Controller.UseProps(this.gameObject);
            }
        }
    }

    public void Dead()
    {
        switch (haveShield)
        {
            case true:
                StartCoroutine(player_Controller._props_Controller.Shield_GameObject.Shield_Delete(this));
                //player_Controller._props_Controller.Shield_GameObject.Shield_Delete(this);
                break;

            case false:
                Destroy(this.gameObject);
                break;
        }

    }
}
