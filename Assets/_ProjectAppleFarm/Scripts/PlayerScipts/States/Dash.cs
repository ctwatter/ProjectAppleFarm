// Herman for animations
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace PlayerState
{
    [Serializable]
    public class Dash : State
    {
        // Set fields here
        public Dash( PlayerStateMachine _fsm ) : base( _fsm )
        {
            base.name = "Dash";
            parent = fsm.InputState;
        }

        public override void OnStateEnter()
        {
            Debug.Log("Entering Dash");
            //SetDefaultState( fsm.Test3 );
        }

        public override void OnStateUpdate()
        {
            if(player.playerBasicAttack)
            {
                player.playerBasicAttack = false;
                //SetState(fsm.Test4);
            }
        }

        public override void OnStateFixedUpdate()
        {
          
        }

        public override void OnStateExit()
        {
            Debug.Log("Exiting Dash");
        }
    }
}
/*public class PlayerDashState : PlayerBaseState
{
    float startTime = 0;
    private PlayerController playerController;
    public PlayerAnimator playerAnimator => playerController.animator;
    public Vector3 startRotation;
    


    public PlayerDashState(PlayerController _playerController) : base(_playerController.gameObject) {
        playerController = _playerController;
    }


    public override void Enter()
    {
        playerController.playerDash = false;
        playerAnimator.Dash();
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
            //playerAnimator.SetRun(false);
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
}*/
