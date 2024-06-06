using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public List<GameObject> all_propsItem_Prefab;
    public Player_Location thisBox_Location; //���c�l����m
    private int[] prop_Generation_Probability = new int[] { 60, 40 }; //���䬰�X�{�D����v(60%)

    private int GetRandow(int[] array) //��J���v�}�C
    {
        int total = 0; //�}�C�����v�`�M

        foreach (int i in array) //�p��}�C�����v�`�M
        {
            total += i;
        }

        int rd = Random.Range(0, total + 1);
        int tmp = 0;

        for (int i = 0; i < array.Length; i++)
        {
            tmp += array[i];
            if (rd < tmp)
            {
                return i;
            }
        }
        return 0;
    }

    void InstantiateItem()
    {
        int rd = Random.Range(0, all_propsItem_Prefab.Count);
        Vector3 InstPosition = new Vector3(thisBox_Location._thisMining_area.transform.position.x, all_propsItem_Prefab[rd].transform.position.y, thisBox_Location._thisMining_area.transform.position.z);
        Instantiate(all_propsItem_Prefab[rd], thisBox_Location._thisMining_area.transform.position, all_propsItem_Prefab[rd].transform.rotation);
        Debug.Log(all_propsItem_Prefab[rd]);
    }

    public void DestroyThisBox()
    {
        int i = GetRandow(prop_Generation_Probability);
        switch (i)
        {
            case 0:
                InstantiateItem();
                break;
            case 1:
                Debug.Log("box�S�X�D��");
                break;
            default:
                Debug.LogError("DestroyThisBox()�X�{���~");
                break;
        }
        Destroy(this.gameObject);
    }
}
