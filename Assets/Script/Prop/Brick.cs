using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    //public Brick Brick_Object;
    public int TeamNum;
    int speed = 5;
    int rotateSpeed = 10;
    public GameObject Brick_Model;

    private void FixedUpdate()
    {
        this.gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Brick_Model.transform.Rotate(rotateSpeed, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            if (other.GetComponent<Attack_point_Controllor>() != null && other.GetComponent<Attack_point_Controllor>().TeamNum != TeamNum)�@//�L�k�Q�ۤv���e���I�}�a
                Destroy(this.gameObject);
            if (other.GetComponent<Occupy_point_Controllor>() != null && other.GetComponent<Occupy_point_Controllor>().TeamNum != TeamNum)�@//�L�k�Q�ۤv�������I�}�a
                Destroy(this.gameObject);
            if(other.tag != "Occupy")
                Destroy(this.gameObject);
        }
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (!(player._myTeam.GetHashCode() == TeamNum) && !(TeamNum == 0)) //�p�GPlayer������s�������󦹧���������s���B����0
            {
                player.player_Controller.SetDizzy(2);
                Destroy(this.gameObject);
            }
        }
    }
}
