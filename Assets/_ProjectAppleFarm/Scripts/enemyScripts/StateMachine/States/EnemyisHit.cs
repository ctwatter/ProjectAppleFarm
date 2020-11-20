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
        if(enemy.isHit)
        {
            enemy.isHit = false;
            return typeof(EnemyIsHit);
        }
        //wait till end of animation, return to idle
        //maybe check how many times has been triggered in succession?
        if(!enemy.animator.GetCurrentAnimatorStateInfo(0).IsTag("isHit"))
        {
            Debug.Log("end hit state");
            
            return typeof(EnemyFollowState);
        }
        

        return null;
    }

    public override void Exit()
    {
       Debug.Log("exiting isHit");
    }
}
