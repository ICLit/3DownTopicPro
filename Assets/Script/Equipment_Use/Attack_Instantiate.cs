using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Instantiate : MonoBehaviour
{
    public List<Occupy_point_Controllor> all_Occupy_ChildScript;
    public List<Attack_point_Controllor> all_Attack_ChildScript;
    public int Attack_TeamNum;

    private void Awake()
    {
        for (int i = 0; i < gameObject.transform.GetChild(0).childCount; i++) ////��������I�l����ƶq
        {   //�N�����l����[�Jall_Occupy_ChildScript
            all_Occupy_ChildScript.Add(gameObject.transform.GetChild(0).GetChild(i).gameObject.GetComponent<Occupy_point_Controllor>());
        }
        for (int i = 0; i < gameObject.transform.GetChild(1).childCount; i++) ////��������I�l����ƶq
        {   //�N�����l����[�Jall_Attack_ChildScript
            all_Attack_ChildScript.Add(gameObject.transform.GetChild(1).GetChild(i).gameObject.GetComponent<Attack_point_Controllor>());
        }
    }
    private void Start()
    {
        Destroy(this.gameObject, 0.05f); //0.05���R��
    }

    public void setTeamNum() //�N����s����
    {
        foreach(Occupy_point_Controllor ChildObject in all_Occupy_ChildScript)
        {
            ChildObject.TeamNum = Attack_TeamNum;
        }

        foreach (Attack_point_Controllor ChildObject in all_Attack_ChildScript)
        {
            ChildObject.TeamNum = Attack_TeamNum;
        }
    }

}
