//Author: Jameson
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyIsHit : EnemyBaseState
{
    private Enemy enemy;
    
    

    public EnemyIsHit(Enemy _enemy) : base(_enemy.gameObject){
        enemy = _enemy;
        
    }

    public override void Enter()
    {
     //trigger a hit animation
     enemy.animator.SetTrigger("isHit");
    }

    public override Type Tick()
    {
        //wait till end of animation, return to idle
        //maybe check how many times has been triggered in succession?
        if(!enemy.animator.GetCurrentAnimatorStateInfo(0).IsTag("attack"))
        {
            return typeof(EnemyFollowState);
        }
        

        return null;
    }

    public override void Exit()
    {
       
    }
}
