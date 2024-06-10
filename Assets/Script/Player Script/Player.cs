using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Player_Controller.MyTeam _myTeam; //隊伍
    public Player_Controller.Equipment _equipment; //目前裝備
    public Player_Controller.Props _props; //目前道具

    public float speed; //速度
    public float overheat_value = 0; //過熱值
    public bool isOverheat, isDizzy; //正在過熱，正在暈眩
    public bool haveShield; //持有護盾

    public Player_Controller player_Controller;
    public Player_Location player_Location; //玩家當前位置
    public string[] InputKey = new string[] { "e", "w", "a", "s", "d", "q" }; //鍵位設定

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
            player_Controller.PlayerMove(this.gameObject, InputKey); //玩家移動
        else
            player_Controller.animatorCtrl.Set_isRun(false);
    }
    private void Update()
    {
        if (!isDizzy)
        {
            if (Input.GetKeyDown(InputKey[0])) //按下E鍵後使用裝備
            {
                player_Controller.UseEquipment(this.gameObject);
            }
            if (Input.GetKeyDown(InputKey[5])) //按下Q鍵後使用裝備
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
