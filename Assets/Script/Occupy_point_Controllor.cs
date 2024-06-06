using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Occupy_point_Controllor : MonoBehaviour
{
    // Start is called before the first frame update
    public int TeamNum;
    Mining_area_Controller mining_Area_Controller;
    public List<GameObject> allCollider = new List<GameObject>();
    public GameObject _thisMining_area; //��e�}�U�q��
    public GameObject _fatherMining_area; //��e�}�U�q�Ϫ�������(�[���)

    private void Update()
    {
        if (_thisMining_area != null)
        {
            _fatherMining_area = _thisMining_area.transform.parent.gameObject;
            mining_Area_Controller = _thisMining_area.GetComponent<Mining_area_Controller>();
            mining_Area_Controller.Occupied(TeamNum);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Mining_area"))
        {
            if (!allCollider.Contains(other.gameObject))
                allCollider.Add(other.gameObject);
        }
        _thisMining_area = Judge_the_closest();

    }

    private void OnTriggerExit(Collider other) //�����}�q�ϮɡA���XallCollider
    {
        if (allCollider.Contains(other.gameObject) && other.CompareTag("Mining_area"))
            allCollider.Remove(other.gameObject);
    }

    GameObject Judge_the_closest() //���o�̾a��}�U���q��
    {
        GameObject closest_MiniArea = _thisMining_area;
        Vector3 closest_trasform = new Vector3(Mathf.Infinity, Mathf.Infinity, Mathf.Infinity);
        foreach (GameObject g in allCollider)
        {
            Vector3 player_trasform = transform.position; //Vector3 g_trasform = g.transform.position;
            if (Vector3.Distance(player_trasform, g.transform.position) < Vector3.Distance(player_trasform, closest_trasform))
            {
                closest_trasform = g.transform.position;
                closest_MiniArea = g;
            }
        }
        return closest_MiniArea;
    }
}
