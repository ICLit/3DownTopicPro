using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mines : MonoBehaviour
{
    public Mines Mines_GameObject;
    public GameObject mines_Attack; //地雷攻擊prefab物件
    public int TeamNum;
    bool _isActivation = false; //是否啟動
    public GameObject mines_model; //地雷的模型

    private void OnTriggerEnter(Collider other)
    {
        if (_isActivation && other.GetComponent<Player>() != null) //若地雷已啟動，且觸碰到玩家
        {
            if (other.GetComponent<Player>()._myTeam.GetHashCode() != TeamNum) //若不是自己的話
                Blasting(this.gameObject);
        }
    }

    public void Blasting(GameObject mines)
    {
        GameObject p_attack = Instantiate(mines_Attack, mines.transform.position, Quaternion.identity); //生成攻擊物件
        Attack_Instantiate attack = p_attack.GetComponent<Attack_Instantiate>();
        attack.Attack_TeamNum = TeamNum; //將攻擊物件的隊伍填進Attack_Instantiate
        attack.setTeamNum();

        Destroy(mines);
    }

    public IEnumerator Mine_Activation(GameObject mines) //地雷啟動
    {
        yield return new WaitForSeconds(2);

        Debug.Log("地雷啟動(隱形)");
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
