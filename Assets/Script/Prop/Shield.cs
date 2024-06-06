using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public bool isBroken;
    private Coroutine shieldOpenCoroutine;
    private Coroutine shieldFollowCoroutine;
    private GameObject thisShield;

    private void Start()
    {
        isBroken = false;
    }
    void Update()
    {
        if (isBroken == true)
        {
            //Destroy(this.gameObject);
            Destroy(thisShield);
        }
    }

    public void StartShield(GameObject player, GameObject shield)
    {
        if (shieldOpenCoroutine != null)
        {
            StopCoroutine(shieldOpenCoroutine);
        }
        if (shieldFollowCoroutine != null)
        {
            StopCoroutine(shieldFollowCoroutine);
        }
        shieldOpenCoroutine = StartCoroutine(Shield_Open(player, shield));
        thisShield = shield;
    }


    public IEnumerator Shield_Open(GameObject player, GameObject shield)
    {
        Player _player = player.transform.GetComponent<Player>();
        _player.haveShield = true;
        shieldFollowCoroutine = StartCoroutine(Shield_Follow(player, shield));

        yield return new WaitForSeconds(4f); //護盾持續時間

        Debug.Log("Shield 時間到了");
        StartCoroutine(Shield_Delete(_player));


        yield return null;
    }

    public IEnumerator Shield_Follow(GameObject player, GameObject shield)
    {
        Player _player = player.GetComponent<Player>();

        //Debug.Log(shield);

        while (_player.haveShield)
        {
            shield.transform.position = player.transform.position;
            yield return new WaitForFixedUpdate();
        }

        yield return null;
    }

    public IEnumerator Shield_Delete(Player _player) //護盾消失
    {
        if (shieldOpenCoroutine != null)
        {
            StopCoroutine(shieldOpenCoroutine);
        }
        if (shieldFollowCoroutine != null)
        {
            StopCoroutine(shieldFollowCoroutine);
        }

        yield return new WaitForSeconds(0.2f);

        _player.haveShield = false;

        Destroy(_player.player_Controller.nowShield_Object);

        yield return null;
    }
}
