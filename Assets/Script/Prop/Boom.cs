using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public Boom Boom_GameObject;
    public GameObject boom_Attack; //炸彈攻擊prefab物件
    public int TeamNum;

    /*public void Use(GameObject boom, int teamNum)
    {

        StartCoroutine(Delay_3_Sencen(boom.transform.gameObject, teamNum));

    }*/
    public void Blasting(GameObject boom) //引爆
    {
        GameObject p_attack = Instantiate(boom_Attack, boom.transform.position, Quaternion.identity); //生成攻擊物件
        Attack_Instantiate attack = p_attack.GetComponent<Attack_Instantiate>();
        attack.Attack_TeamNum = TeamNum; //將攻擊物件的隊伍填進Attack_Instantiate
        attack.setTeamNum();

        Destroy(boom);
    }

    public IEnumerator Boom_Activation(GameObject boom) //炸彈啟動(三秒後爆炸)
    {
        yield return new WaitForSeconds(3); //等三秒

        Debug.Log("炸彈爆炸");
        Blasting(boom);

        yield return null;
    }
}
