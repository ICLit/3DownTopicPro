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
        for (int i = 0; i < gameObject.transform.GetChild(0).childCount; i++) ////獲取佔領點子物件數量
        {   //將全部子物件加入all_Occupy_ChildScript
            all_Occupy_ChildScript.Add(gameObject.transform.GetChild(0).GetChild(i).gameObject.GetComponent<Occupy_point_Controllor>());
        }
        for (int i = 0; i < gameObject.transform.GetChild(1).childCount; i++) ////獲取攻擊點子物件數量
        {   //將全部子物件加入all_Attack_ChildScript
            all_Attack_ChildScript.Add(gameObject.transform.GetChild(1).GetChild(i).gameObject.GetComponent<Attack_point_Controllor>());
        }
    }
    private void Start()
    {
        Destroy(this.gameObject, 0.05f); //0.05秒後刪除
    }

    public void setTeamNum() //將隊伍編號給
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
