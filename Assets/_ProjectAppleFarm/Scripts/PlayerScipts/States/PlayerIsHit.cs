// Jake
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerIsHit : PlayerBaseState
{
    private PlayerController player;
    
    public PlayerIsHit(PlayerController _player) : base(_player.gameObject){
        player = _player;
    }

    public override void Enter(){
        //enter anim
        player.playerAnimator.animator.SetTrigger("isHit");
    }

    public override Type Tick() {
        if(player.isHit)
        {
            player.isHit = false;
            return typeof(PlayerIsHit);
        }
        //wait till end of animation, return to idle
        //maybe check how many times has been triggered in succession?
        if(!player.playerAnimator.animator.GetCurrentAnimatorStateInfo(0).IsTag("isHit"))
        {
            //Debug.Log("End Player hit state");
            
            return typeof(PlayerIdleState);
        }
        return null;
    }


    public override void PhysicsTick()
    {
        
    }

    public override void Exit(){
        //exit anim
       // Debug.Log("Exiting Player isHit");
    }
}
