﻿// Herman

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public GameObject model;
    private Animator animator => model.GetComponent<Animator>();
    private PlayerController playerController => GetComponent<PlayerController>();

    public bool isAttack { get; private set; }
    public bool isFollowThrough { get; private set; }

    // Triggered by event
    public void AttackDone()
    {
        isAttack = false;
    }

    // Triggered by event
    public void FollowThroughDone()
    {
        isAttack = false;
        isFollowThrough = false;
    }

    public void ResetAttackAnim()
    {
        isAttack = false;
        isFollowThrough = false;
    }

    public void ResetAllAttackAnims()
    {
        isAttack = false;
        isFollowThrough = false;

        animator.ResetTrigger("Attack0");
        animator.ResetTrigger("Attack1");
        animator.ResetTrigger("Attack2");
    }

    public void Attack( int num )
    {
        isAttack = true;
        isFollowThrough = true;

        animator.SetTrigger("Attack" + num.ToString() );
    }

    public void SetDamaged()
    {
        // HERMAN TODO: Fill in actual animation later
        animator.SetTrigger("isHit");
    }

    // HERMAN TODO: Fill in with actual animation later
    public bool IsDamaged()
    {
        return false;
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
        if (movementVector.magnitude > 0)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }

    public void OnIdle()
    {
        this.ResetAttackAnim();

        animator.ResetTrigger("Attack0");
        animator.ResetTrigger("Attack1");
        animator.ResetTrigger("Attack2");
        animator.ResetTrigger("Dash");
    }
}
