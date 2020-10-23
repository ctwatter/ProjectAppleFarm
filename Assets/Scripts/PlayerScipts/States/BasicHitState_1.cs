//Colin and Jamo
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class BasicHitState_1 : PlayerBaseState
{
    // bool punchAlternate = true;
    // public int noOfPresses = 0;
    // float lastPressTime = 0;
    // public float maxComboDelay;

    private PlayerController playerController;
    public Animator playerAnimator => playerController.playerAnimator;


    public BasicHitState_1(PlayerController _playerController) : base(_playerController.gameObject) {
        playerController = _playerController;
    }


    public override void Enter(){
        //enter anim
       
            playerAnimator.SetTrigger("attack1");
            //punchAlternate = !punchAlternate;

    }

    public override Type Tick() {
        Debug.Log("Attack State");
        
        if(playerController.isAnimDone)
        {
            playerController.isAnimDone = false;
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
