using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animator_Controller : MonoBehaviour
{
    public Animator animator;

    public void Set_isRun(bool TorF)
    {
        animator.SetBool("isRun", TorF);
    }
    public void Set_Pd_Attack()
    {
        animator.SetTrigger("Pd_Attack");
    }
    public void Set_Dh_Attack()
    {
        animator.SetTrigger("Dh_Attack");
    }
}
