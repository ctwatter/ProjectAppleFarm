using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAttack1State : PlayerBaseState
{
    private PlayerController playerController;


    public PlayerAttack1State(PlayerController _playerController) : base(_playerController.gameObject) {
        playerController = _playerController;
    }


    public override void Enter(){
        //enter anim
    }

    public override Type Tick() {
        Debug.Log("Attack State");
        return typeof(PlayerIdleState);
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
        playerController.doRotation(1f);
    }

    public override void Exit(){
        //exit anim
    }
}
