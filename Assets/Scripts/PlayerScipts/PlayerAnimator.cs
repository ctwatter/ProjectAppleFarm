// Herman

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public GameObject model;
    private Animator animator => model.GetComponent<Animator>();

    public void Attack0()
    {
        animator.SetTrigger("Attack0");
    }

    public void Attack1()
    {
        animator.SetTrigger("Attack1");
    }

    public void Attack2()
    {
        animator.SetTrigger("Attack2");
    }

    public void Dash()
    {
        animator.SetTrigger("Dash");

        animator.ResetTrigger("Attack0");
        animator.ResetTrigger("Attack1");
        animator.ResetTrigger("Attack2");
    }

    public void SetRun(bool state)
    {
        animator.SetBool("Run", state);
    }

    public void Move(Vector3 movementVector)
    {
        if (movementVector.magnitude > 0){
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }

    public void OnIdle()
    {
        animator.ResetTrigger("Attack0");
        animator.ResetTrigger("Attack1");
        animator.ResetTrigger("Attack2");
        animator.ResetTrigger("Dash");
    }
}
