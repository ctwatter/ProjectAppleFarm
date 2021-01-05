// Herman

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public GameObject model;
    private Animator animator => model.GetComponent<Animator>();
    private PlayerController playerController => GetComponent<PlayerController>();

    public void attackBegin()
    {
        playerController.setIsAttackAnim(true);
        playerController.setIsFollowThroughAnim(true);
    }

    public void attackDone()
    {
        playerController.setIsAttackAnim(false);
    }

    public void followThroughDone()
    {
        playerController.setIsAttackAnim(false);
        playerController.setIsFollowThroughAnim(false);
    }

    public void resetAttackAnim()
    {
        playerController.setIsAttackAnim(false);
        playerController.setIsFollowThroughAnim(false);
    }

    public void resetAllAttackAnims()
    {
        playerController.setIsAttackAnim(false);
        playerController.setIsFollowThroughAnim(false);

        animator.ResetTrigger("Attack0");
        animator.ResetTrigger("Attack1");
        animator.ResetTrigger("Attack2");
    }

    public void Attack( int num )
    {
        this.attackBegin();
        animator.SetTrigger("Attack" + num.ToString() );
    }

    public void SetDamaged()
    {
        // HERMAN TODO: Fill in actual animation later
        animator.SetTrigger("isHit");
    }

    public bool IsDamaged()
    {
        return true;
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
        this.resetAttackAnim();

        animator.ResetTrigger("Attack0");
        animator.ResetTrigger("Attack1");
        animator.ResetTrigger("Attack2");
        animator.ResetTrigger("Dash");
    }
}
