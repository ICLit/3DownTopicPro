using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mines : MonoBehaviour
{
    public Mines Mines_GameObject;
    public GameObject mines_Attack; //�a�p����prefab����
    public int TeamNum;
    bool _isActivation = false; //�O�_�Ұ�
    public GameObject mines_model; //�a�p���ҫ�

    private void OnTriggerEnter(Collider other)
    {
        if (_isActivation && other.GetComponent<Player>() != null) //�Y�a�p�w�ҰʡA�BĲ�I�쪱�a
        {
            if (other.GetComponent<Player>()._myTeam.GetHashCode() != TeamNum) //�Y���O�ۤv����
                Blasting(this.gameObject);
        }
    }

    public void Blasting(GameObject mines)
    {
        GameObject p_attack = Instantiate(mines_Attack, mines.transform.position, Quaternion.identity); //�ͦ���������
        Attack_Instantiate attack = p_attack.GetComponent<Attack_Instantiate>();
        attack.Attack_TeamNum = TeamNum; //�N�������󪺶����iAttack_Instantiate
        attack.setTeamNum();

        Destroy(mines);
    }

    public IEnumerator Mine_Activation(GameObject mines) //�a�p�Ұ�
    {
        yield return new WaitForSeconds(2);

        Debug.Log("�a�p�Ұ�(����)");
        _isActivation = true;
        StartCoroutine(Invisible());

        yield return null;
    }

    public IEnumerator Invisible()
    {
        Color c = mines_model.GetComponent<MeshRenderer>().material.color;

        for (float f = 1f; f >= 25f / 255f; f -= 10f / 255f)
        {
            c = mines_model.GetComponent<MeshRenderer>().material.color;
            c.a = f;
            mines_model.GetComponent<MeshRenderer>().material.color = c;
            yield return new WaitForSeconds(0.1f);
        }


        yield return null;
    }
}
