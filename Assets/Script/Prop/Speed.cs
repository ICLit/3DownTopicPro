using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public IEnumerator SpeedOpen(GameObject player)
    {
        Player _player = player.transform.GetComponent<Player>();
        _player.speed += 5;
        Debug.Log("speed �[ �t");
        yield return new WaitForSeconds(5f);

        _player.speed -= 5;
        Debug.Log("speed �� �t");

        yield return null;
    }
}
