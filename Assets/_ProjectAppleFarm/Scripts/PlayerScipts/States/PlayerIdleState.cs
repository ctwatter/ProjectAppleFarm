using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerIdleState : PlayerBaseState
{

    private PlayerController playerController;
    public PlayerAnimator playerAnimator => playerController.playerAnimator;

    public PlayerIdleState(PlayerController _playerController) : base(_playerController.gameObject) {
        playerController = _playerController;
    }


    public override void Enter(){
        //enter anim
        playerAnimator.OnIdle();
    }


    public override Type Tick() {
        if(playerController.isHit)
        {
            playerController.isHit = false;
            return typeof(PlayerIsHit);
        }
        if(playerController.playerDash){
            
            return(typeof(PlayerDashState));
        }
        if(playerController.playerBasicAttack) {
            //playerController.playerBasicAttack = false;
            return(typeof(BasicHitState_0));
        }
       
        //do idle anim
        return null;
    }

    public override void PhysicsTick()
    {
        playerController.doMovement(1f);
        playerController.doRotation(1f);
    }

    public override void Exit(){
        //exit anim
    }
}
