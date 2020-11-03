using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerDashState : PlayerBaseState
{
    float startTime = 0;
    private PlayerController playerController;
     public Animator playerAnimator => playerController.playerAnimator;
    public Vector3 startRotation;
    


    public PlayerDashState(PlayerController _playerController) : base(_playerController.gameObject) {
        playerController = _playerController;
    }


    public override void Enter()
    {
        playerController.playerDash = false;
        playerAnimator.SetTrigger("dash");
        playerController.isDashing = true;
        startTime = Time.time;
        startRotation = playerController.v3Vel;
        playerController.setRotation(startRotation);
    }

   

    public override Type Tick() {
        
        //checks if time in this state has reached limit
        if(Time.time > startTime + playerController.dashTime)
        {
            playerController.isDashing = false;
            playerAnimator.SetTrigger("idle");
            return typeof(PlayerIdleState);
        }
       
        return null;
    }

    public override void PhysicsTick()
    {
        playerController.doMovement(playerController.dashSpeed);
        playerController.setRotation(startRotation);
       
    }

    public override void Exit(){
        //exit anim
    }
}
