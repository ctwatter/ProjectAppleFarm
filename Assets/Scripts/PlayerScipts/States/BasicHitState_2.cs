//Colin and Jamo
// Herman for animations
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class BasicHitState_2 : PlayerBaseState
{
    // bool punchAlternate = true;
    // public int noOfPresses = 0;
    // float lastPressTime = 0;
    // public float maxComboDelay;

    private PlayerController playerController;
    public PlayerAnimator playerAnimator => playerController.playerAnimator;

    public CapsuleCollider swordCollider; 


    public BasicHitState_2(PlayerController _playerController) : base(_playerController.gameObject) {
        playerController = _playerController;
    }


    public override void Enter(){
        //enter anim
           // playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
            playerController.playerBasicAttack = false;
            
            playerController.swordCollider.enabled = true;
            playerAnimator.Attack2();
            Debug.Log("assigned enter");
            //punchAlternate = !punchAlternate;

    }

    public override Type Tick() {
        //Debug.Log("Attack State");
         if(playerController.playerDash)
        {
            playerController.isAnimDone = false;
            playerController.swordCollider.enabled = false;
            return typeof(PlayerDashState);
        }
        if(playerController.isAnimDone)
        {
            //for going to 4th attack
            // playerController.isAnimDone = false;
            // swordCollider.enabled = false;
            // Debug.Log("Attack 2");
            // if(playerController.playerBasicAttack){
            //     playerController.playerBasicAttack = false;
            //     return typeof(BasicHitState_3);
            // }
            // playerAnimator.SetRun(false);
            // return typeof(PlayerIdleState);

            playerController.isAnimDone = false;
            playerController.swordCollider.enabled = false;
            //Debug.Log("Attack 3");
           // Debug.Log("leaving");
            playerAnimator.SetRun(false);
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

    public void punch1AnimDone()
    {
        playerController.isAnimDone = true;
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
