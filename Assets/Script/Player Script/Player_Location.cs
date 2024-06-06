using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Location : MonoBehaviour
{
    public List<GameObject> allCollider = new List<GameObject>(); //�I���餺�������q��
    public GameObject _thisMining_area; //��e�}�U�q��
    public GameObject _fatherMining_area; //��e�}�U�q�Ϫ�������(�[���)

    private void Update()
    {
        if (_thisMining_area != null) //����q�Ϫ�������
        {
            _fatherMining_area = _thisMining_area.transform.parent.gameObject;
        }
    }

    private void OnTriggerStay(Collider other) //�ˬd�I���餺������
    {
        if (other.CompareTag("Mining_area")) //�Y�䬰�q��
        {
            if (!allCollider.Contains(other.gameObject)) //�Y���ballCollider��
                allCollider.Add(other.gameObject); //�h�[�JallCollider
        }
        _thisMining_area = Judge_the_closest(); //���o�̪��q��
    }

    private void OnTriggerExit(Collider other) //�����}�q�ϮɡA���XallCollider
    {
        if (allCollider.Contains(other.gameObject) && other.CompareTag("Mining_area"))
            allCollider.Remove(other.gameObject);
    }

    GameObject Judge_the_closest() //���o�̾a��}�U���q��
    {
        GameObject closest_MiniArea = _thisMining_area; //��e���̪��q��
        Vector3 closest_trasform = new Vector3(Mathf.Infinity, Mathf.Infinity, Mathf.Infinity);
        foreach (GameObject g in allCollider)  //�ˬdList���������q��
        {
            Vector3 player_trasform = transform.position; //���o���a��m

            //�Y List�����ˬd���q�� �P ���a��m ���Z�� �p�� ��e�̪��q�� �P ���a��m ���Z��
            if (Vector3.Distance(player_trasform, g.transform.position) < Vector3.Distance(player_trasform, closest_trasform))
            {
                closest_trasform = g.transform.position; //��s�̪�Z��
                closest_MiniArea = g; //��s�̪��q��
            }
        }
        return closest_MiniArea; //�b�ˬd��List���������q�ϫ�A��s�̪��q��
    }
}
