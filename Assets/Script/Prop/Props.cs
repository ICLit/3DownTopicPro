using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Props : MonoBehaviour
{
    public Player_Controller.Props _thisProps; //此掉落物的道具類型
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();
            Debug.Log($"{player._myTeam}撿取{_thisProps}");
            player._props = _thisProps;
            Destroy(this.gameObject);
        }
    }
}
