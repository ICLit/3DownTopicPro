using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public Boom Boom_GameObject;
    public GameObject boom_Attack; //���u����prefab����
    public int TeamNum;

    /*public void Use(GameObject boom, int teamNum)
    {

        StartCoroutine(Delay_3_Sencen(boom.transform.gameObject, teamNum));

    }*/
    public void Blasting(GameObject boom) //���z
    {
        GameObject p_attack = Instantiate(boom_Attack, boom.transform.position, Quaternion.identity); //�ͦ���������
        Attack_Instantiate attack = p_attack.GetComponent<Attack_Instantiate>();
        attack.Attack_TeamNum = TeamNum; //�N�������󪺶����iAttack_Instantiate
        attack.setTeamNum();

        Destroy(boom);
    }

    public IEnumerator Boom_Activation(GameObject boom) //���u�Ұ�(�T����z��)
    {
        yield return new WaitForSeconds(3); //���T��

        Debug.Log("���u�z��");
        Blasting(boom);

        yield return null;
    }
}
