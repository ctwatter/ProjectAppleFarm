//Colin and Jamo
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class PlayerAttack1State : PlayerBaseState
{
    // bool punchAlternate = true;
    // public int noOfPresses = 0;
    // float lastPressTime = 0;
    // public float maxComboDelay;

    private PlayerController playerController;
    private PlayerStats playerStats; 
    public Animator playerAnimator => playerController.playerAnimator;
    //gets the swords collider, currently is a capsule
    public CapsuleCollider swordCollider; 


    public PlayerAttack1State(PlayerController _playerController) : base(_playerController.gameObject) {
        playerController = _playerController;
    }


    public override void Enter(){
        //enter anim
           // playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
           // swordCollider = GameObject.FindGameObjectWithTag("Weapon").GetComponent<CapsuleCollider>();
            //swordCollider.enabled = true;
            playerAnimator.SetTrigger("attack1");
            Debug.Log("assigned enter");
            //punchAlternate = !punchAlternate;

    }

    public override Type Tick() {
        //Debug.Log("Attack State");
        
        if(playerController.isAnimDone)
        {
            
            playerController.isAnimDone = false;
            //swordCollider.enabled = false;
            Debug.Log("leaving");
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

    //sword collides with enemy
    

    public override void Exit(){
        //exit anim
    }
}
