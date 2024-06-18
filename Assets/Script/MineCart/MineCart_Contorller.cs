using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineCart_Contorller : MonoBehaviour
{
    public Minecart[] Minecarts;
    public Transform startPont;
    public Transform endPont;
    float timer;

    private void Start()
    {
        MinecartsGo();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > 20)
        {
            MinecartsGo();
            timer = 0;
        }
    }

    public void MinecartsGo()
    {
        if (Minecarts.Length <= 0)
            return;

        int i = Random.Range(0, Minecarts.Length);
        Minecart minecart = Instantiate(Minecarts[i], startPont.position, startPont.rotation);
        minecart.mineCart_Contorller = this;
        minecart.MinecraStartCoroutine();
    }
}
