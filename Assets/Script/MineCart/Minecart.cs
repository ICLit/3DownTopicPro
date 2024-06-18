using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minecart : MonoBehaviour
{
    public MineCart_Contorller mineCart_Contorller;
    float speed = 5f;


    public void MinecraStartCoroutine()
    {
        StartCoroutine(MinecartGo());
    }

    public IEnumerator MinecartGo()
    {
        float timer = 0;

        while (timer < 5)
        {
            //寫要每幀調用的程式碼
            MinecartMove();
            timer += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }

        yield return null;

        Destroy(this.gameObject);

        yield return null;
    }

    public void MinecartMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, mineCart_Contorller.endPont.transform.position, speed * Time.deltaTime);
    }
}
