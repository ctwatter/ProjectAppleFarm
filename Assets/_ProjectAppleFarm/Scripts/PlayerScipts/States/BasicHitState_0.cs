﻿//Colin and Jamo
// Herman for animations
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class BasicHitState_0 : PlayerBaseState
{
    // bool punchAlternate = true;
    // public int noOfPresses = 0;
    // float lastPressTime = 0;
    // public float maxComboDelay;

    private PlayerController playerController;
    public PlayerAnimator playerAnimator => playerController.playerAnimator;

    public CapsuleCollider swordCollider; 


    public BasicHitState_0(PlayerController _playerController) : base(_playerController.gameObject) {
        playerController = _playerController;
    }


    public override void Enter(){
        //enter anim
        //Debug.Log("Enter State 0");
        playerController.playerBasicAttack = false;
        
        playerController.swordCollider.enabled = true;
        playerAnimator.Attack0();
    }

    public override Type Tick() {
        //Debug.Log("Attack State");
        if(playerController.playerDash)
        {
            playerAnimator.resetAllAttackAnims();
            playerController.swordCollider.enabled = false;
            return typeof(PlayerDashState);
        }
        if(!playerController.getIsAttackAnim())
        {
            
            playerController.setIsAttackAnim(false);

            playerController.swordCollider.enabled = false;

            if(playerController.playerBasicAttack){
                playerController.playerBasicAttack = false;
                return typeof(BasicHitState_1);
            }
            playerAnimator.SetRun(false);

            if(!playerController.getIsFollowThroughAnim()){
                playerAnimator.resetAllAttackAnims();
                return typeof(PlayerIdleState);
            }
        } 
        //disable movement?
        //trigger attack animation
        
        //apply hitbox on area
        //
        //on animation done enable movement/
        
        //do idle anim
        return null;
    }


    public override void PhysicsTick()
    {
        playerController.doMovement(0.3f);
        playerController.doRotation(0.6f);
    }

    public override void Exit(){
        //exit anim
    }
}
