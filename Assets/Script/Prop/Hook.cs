using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public int TeamNum;
    public Player player;
    int speed = 20;

    private void FixedUpdate()
    {
        this.gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && other.tag != "Item" && other.tag != "Occupy")
        {
            Vector3 hitPoint = other.bounds.ClosestPoint(transform.position);
            FlyToHookpoint(hitPoint);

            if (other.GetComponent<Attack_point_Controllor>() != null && other.GetComponent<Occupy_point_Controllor>() != null) //無法被占領點&攻擊點觸發
            {

            }
        }
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (!(player._myTeam.GetHashCode() == TeamNum) && !(TeamNum == 0)) //如果Player的隊伍編號不等於此攻擊的隊伍編號且不為0
            {
                Vector3 hitPoint = other.bounds.ClosestPoint(transform.position);
                FlyToHookpoint(hitPoint);
            }
        }
    }

    public void FlyToHookpoint(Vector3 hitPoint)
    {
        if (player == null)
            return;

        Debug.Log("鈎爪固定" + hitPoint);
        player.player_Controller.StartMoveToHookFixedPosition(hitPoint);
        
        Destroy(this.gameObject);
    }


}
