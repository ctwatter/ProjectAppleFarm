﻿//Jamo
// Herman for animations
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class HeavyChargeState : PlayerBaseState
{
    private PlayerController playerController;
    public PlayerAnimator playerAnimator => playerController.playerAnimator;
    public CapsuleCollider swordCollider; 
    ParticleSystem vfx;

    


    public HeavyChargeState(PlayerController _playerController) : base(_playerController.gameObject) {
        playerController = _playerController;
    }


    public override void Enter(){
      
        //soon to be deprecated
        
        playerController.swordCollider.enabled = true;
        playerController.heavyChargeVfx.Play();

        //trigger charge animation

        //Debug.Log("heavy charge state");
        //vfx = gameObject.GetComponentInChildren<ParticleSystem>();
            

    }

    public override Type Tick() {
       
        //check for input action to be cancelled,
        //action.canceled += ctx => /* Action was canceled */; 
        //if so then
        if(playerController.playerHeavyAttack == false) return typeof(HeavyHitState);
        
        //make ui rnage indicator grow over time, or just trigger it idk
        
        return null;
    }

    public override void PhysicsTick()
    {
        playerController.doMovement(0f);
        playerController.doRotation(0f);
    }

    public override void Exit(){
        //exit anim
        //reset
        playerController.heavyChargeVfx.Stop();
    }
}
