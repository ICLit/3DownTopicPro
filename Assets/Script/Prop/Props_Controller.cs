using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Props_Controller : MonoBehaviour
{
    public Boom Boom_GameObject;
    public Mines Mines_GameObject;
    public Speed Speed_Script;
    public Shield Shield_GameObject;
    public Brick Brick_GameObject;
    public Hook Hook_GameObject;

    public void UseMines(GameObject player, int teamNum)
    {
        GameObject Mining_area_under_the_player = player.GetComponent<Player>().player_Location._thisMining_area; //獲取玩家腳下的礦區
        if (Mining_area_under_the_player != null) //如果玩家腳下的礦區不為空
        {
            Vector3 playerTransform = Mining_area_under_the_player.transform.parent.position;
            Mines mines = Instantiate(Mines_GameObject, playerTransform, Quaternion.identity); //生成物件
            mines.TeamNum = teamNum;
            StartCoroutine(mines.Mine_Activation(mines.transform.gameObject));
        }
    }
    public void UseBoom(GameObject player, int teamNum)
    {
        GameObject Mining_area_under_the_player = player.GetComponent<Player>().player_Location._thisMining_area; //獲取玩家腳下的礦區
        if (Mining_area_under_the_player != null) //如果玩家腳下的礦區不為空
        {
            Vector3 playerTransform = Mining_area_under_the_player.transform.parent.position;
            Boom boom = Instantiate(Boom_GameObject, playerTransform, Quaternion.identity); //生成物件
            boom.TeamNum = teamNum; //設定炸彈的隊伍資訊
            boom.StartCoroutine(boom.Boom_Activation(boom.transform.gameObject)); //啟動炸藥
        }
    }

    public void UseSpeed(GameObject player)
    {
        StartCoroutine(Speed_Script.SpeedOpen(player));
    }

    public void UseShield(GameObject player)
    {
        Player _player = player.GetComponent<Player>();
        GameObject Mining_area_under_the_player = _player.player_Location._thisMining_area; //獲取玩家腳下的礦區
        if (Mining_area_under_the_player != null) //如果玩家腳下的礦區不為空
        {
            Vector3 playerTransform = Mining_area_under_the_player.transform.parent.position;
            Shield shield = Instantiate(Shield_GameObject, playerTransform, Quaternion.identity); //生成物件
            shield.StartShield(player, shield.transform.gameObject);
            if (_player.player_Controller.nowShield_Object != null)
            {
                Destroy(_player.player_Controller.nowShield_Object);
            }
            _player.player_Controller.nowShield_Object = shield.gameObject;
        }
    }

    public void UseBrick(GameObject player, int teamNum)
    {
        Player _player = player.GetComponent<Player>();
        GameObject Mining_area_under_the_player = _player.player_Location._thisMining_area; //獲取玩家腳下的礦區
        if (Mining_area_under_the_player != null) //如果玩家腳下的礦區不為空
        {
            Vector3 playerTransform = Mining_area_under_the_player.transform.parent.position;
            Vector3 InstantiateTransform = new Vector3(playerTransform.x, player.transform.position.y, playerTransform.z);
            Brick brick = Instantiate(Brick_GameObject, InstantiateTransform, player.transform.rotation); //生成物件
            brick.TeamNum = teamNum;
        }
    }

    public void UseHook(GameObject player, int teamNum)
    {
        Player _player = player.GetComponent<Player>();
        GameObject Mining_area_under_the_player = _player.player_Location._thisMining_area; //獲取玩家腳下的礦區
        if (Mining_area_under_the_player != null) //如果玩家腳下的礦區不為空
        {
            Vector3 playerTransform = Mining_area_under_the_player.transform.parent.position;
            Vector3 InstantiateTransform = new Vector3(playerTransform.x, player.transform.position.y, playerTransform.z);
            Hook hook = Instantiate(Hook_GameObject, InstantiateTransform, player.transform.rotation); //生成物件
            hook.TeamNum = teamNum;
            hook.player = _player;
        }
    }
}
