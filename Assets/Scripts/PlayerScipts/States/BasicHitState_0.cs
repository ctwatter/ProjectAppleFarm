//Colin and Jamo
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
    public Animator playerAnimator => playerController.playerAnimator;

    public CapsuleCollider swordCollider; 


    public BasicHitState_0(PlayerController _playerController) : base(_playerController.gameObject) {
        playerController = _playerController;
    }


    public override void Enter(){
        //enter anim
            playerController.playerBasicAttack = false;
            swordCollider = GameObject.FindGameObjectWithTag("Weapon").GetComponent<CapsuleCollider>();
            swordCollider.enabled = true;
            playerAnimator.SetTrigger("attack0");
            Debug.Log("basic state 0");
            

    }

    public override Type Tick() {
        //Debug.Log("Attack State");
        if(playerController.playerDash)
        {
            playerController.isAnimDone = false;
            swordCollider.enabled = false;
            return typeof(PlayerDashState);
        }
        if(playerController.isAnimDone)
        {
            
            playerController.isAnimDone = false;
            swordCollider.enabled = false;
            Debug.Log("Attack 0");
            if(playerController.playerBasicAttack){
                playerController.playerBasicAttack = false;
                return typeof(BasicHitState_1);
            }
            playerAnimator.SetTrigger("idle");
            return typeof(PlayerIdleState);
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
        playerController.doMovement(0.1f);
        playerController.doRotation(0.1f);
    }

    public override void Exit(){
        //exit anim
    }
}
