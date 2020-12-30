﻿//Jamo
// Herman for animations
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

namespace PlayerState
{
    [Serializable]
    public class HeavySlash : State
    {
        // Set fields here
        public HeavySlash( PlayerStateMachine _fsm ) : base( _fsm )
        {
            base.name = "HeavySlash";
            parent = fsm.InputState;
        }

        public override void OnStateEnter()
        {
            Debug.Log("Entering HeavySlash");
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
            Debug.Log("Exiting HeavySlash");
        }
    }
}
/*public class HeavyHitState : PlayerBaseState
{
    private PlayerController playerController;
    public PlayerAnimator playerAnimator => playerController.animator;
    public CapsuleCollider swordCollider; 
    //public ParticleSystem hitVfx;


    public HeavyHitState(PlayerController _playerController) : base(_playerController.gameObject) {
        playerController = _playerController;
    }


    public override void Enter(){
      
        playerController.playerHeavyAttack= false;
        playerController.swordCollider.enabled = true;

        //Debug.Log("heavy hit state");
        playerController.heavyHitVfx.Play();
            

    }

    public override Type Tick() {
        //Debug.Log("Attack State");

        //return typeof(PlayerIdleState);
        
        return typeof(PlayerIdleState);
        // if(!playerController.getIsAttackAnim())
        // {
            
        //     playerAnimator.resetAttackAnim();

        //     swordCollider.enabled = false;

        //     playerAnimator.SetRun(false);
        //     return typeof(PlayerIdleState);
        // } 
      
        return null;
    }

        public override void PhysicsTick()
    {
        playerController.doMovement(0.1f);
        playerController.doRotation(0.1f);
    }

    public override void Exit(){
        //exit anim
        //reset
    }
}*/