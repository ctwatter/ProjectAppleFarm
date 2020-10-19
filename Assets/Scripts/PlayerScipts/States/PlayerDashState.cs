using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerDashState : PlayerBaseState
{
    private PlayerController playerController;


    public PlayerDashState(PlayerController _playerController) : base(_playerController.gameObject) {
        playerController = _playerController;
    }


    public override void Enter(){
        //enter anim
    }

    public override Type Tick() {
        Debug.Log("Dash State");
        return typeof(PlayerIdleState);
        //disable normal movement
        //apply large movement in movementVel Direction
        //enable movement and transition to movementState/IdleState
        
        //do idle anim
        return null;
    }

    public override void PhysicsTick()
    {
        playerController.doMovement(10f);
        playerController.doRotation(1f);
    }

    public override void Exit(){
        //exit anim
    }
}
