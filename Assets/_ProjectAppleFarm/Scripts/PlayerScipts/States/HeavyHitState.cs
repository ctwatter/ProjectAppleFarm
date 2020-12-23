//Jamo
// Herman for animations
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class HeavyHitState : PlayerBaseState
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
}
