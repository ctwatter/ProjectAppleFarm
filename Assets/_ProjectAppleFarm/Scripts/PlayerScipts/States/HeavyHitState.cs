//Jamo
// Herman for animations
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class HeavyHitState : PlayerBaseState
{
    private PlayerController playerController;
    public PlayerAnimator playerAnimator => playerController.playerAnimator;
    public CapsuleCollider swordCollider; 


    public HeavyHitState(PlayerController _playerController) : base(_playerController.gameObject) {
        playerController = _playerController;
    }


    public override void Enter(){
      
            playerController.playerBasicAttack = false;
            playerController.swordCollider.enabled = true;

            //playerAnimator.Attack2();
            //trigger start of charge animation
            //draw aoe guide

            

    }

    public override Type Tick() {
        //Debug.Log("Attack State");
        if(playerController.playerDash)
        {
            playerAnimator.resetAttackAnim();
            swordCollider.enabled = false;
            return typeof(PlayerDashState);
        }
        if(!playerController.getIsAttackAnim())
        {
            
            playerAnimator.resetAttackAnim();

            swordCollider.enabled = false;

            playerAnimator.SetRun(false);
            return typeof(PlayerIdleState);
        } 
        //disable movement?
        //trigger attack animation
        //wait for animation cue and
        //apply hitbox on area
        //
        //on animation done enable movement/
        
        //do idle anim
        return null;
    }

        public override void PhysicsTick()
    {
        playerController.doMovement(0.1f);
        playerController.doRotation(0.1f);
    }

    public override void Exit(){
        //exit anim
        //reset
    }
}
