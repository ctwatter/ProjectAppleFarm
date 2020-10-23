using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerDashState : PlayerBaseState
{
    float startTime = 0;
    private PlayerController playerController;
    


    public PlayerDashState(PlayerController _playerController) : base(_playerController.gameObject) {
        playerController = _playerController;
    }


    public override void Enter()
    {
        startTime = Time.time;
        playerController.setRotation();
    }

   

    public override Type Tick() {
        Debug.Log("Dash State");
        //checks if time in this state has reached limit
        if(Time.time > startTime + playerController.dashTime)
        {
            return typeof(PlayerIdleState);
        }
       
        return null;
    }

    public override void PhysicsTick()
    {
        playerController.doMovement(playerController.dashSpeed);
        playerController.setRotation();
       
    }

    public override void Exit(){
        //exit anim
    }
}
