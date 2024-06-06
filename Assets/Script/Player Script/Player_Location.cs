using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Location : MonoBehaviour
{
    public List<GameObject> allCollider = new List<GameObject>(); //碰撞體內的全部礦區
    public GameObject _thisMining_area; //當前腳下礦區
    public GameObject _fatherMining_area; //當前腳下礦區的父物件(觀察用)

    private void Update()
    {
        if (_thisMining_area != null) //顯示礦區的父物件
        {
            _fatherMining_area = _thisMining_area.transform.parent.gameObject;
        }
    }

    private void OnTriggerStay(Collider other) //檢查碰撞體內的物件
    {
        if (other.CompareTag("Mining_area")) //若其為礦區
        {
            if (!allCollider.Contains(other.gameObject)) //若不在allCollider內
                allCollider.Add(other.gameObject); //則加入allCollider
        }
        _thisMining_area = Judge_the_closest(); //取得最近礦區
    }

    private void OnTriggerExit(Collider other) //當離開礦區時，移出allCollider
    {
        if (allCollider.Contains(other.gameObject) && other.CompareTag("Mining_area"))
            allCollider.Remove(other.gameObject);
    }

    GameObject Judge_the_closest() //取得最靠近腳下的礦區
    {
        GameObject closest_MiniArea = _thisMining_area; //當前的最近礦區
        Vector3 closest_trasform = new Vector3(Mathf.Infinity, Mathf.Infinity, Mathf.Infinity);
        foreach (GameObject g in allCollider)  //檢查List內的全部礦區
        {
            Vector3 player_trasform = transform.position; //取得玩家位置

            //若 List內所檢查的礦區 與 玩家位置 的距離 小於 當前最近礦區 與 玩家位置 的距離
            if (Vector3.Distance(player_trasform, g.transform.position) < Vector3.Distance(player_trasform, closest_trasform))
            {
                closest_trasform = g.transform.position; //更新最近距離
                closest_MiniArea = g; //更新最近礦區
            }
        }
        return closest_MiniArea; //在檢查完List內的全部礦區後，更新最近礦區
    }
}
