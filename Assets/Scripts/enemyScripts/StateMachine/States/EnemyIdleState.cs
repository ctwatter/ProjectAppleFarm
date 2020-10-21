//Author : Jake
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class EnemyIdleState : EnemyBaseState
{
    private Enemy enemy;
    private GameObject ObjToFollow;
    private NavMeshAgent agent;

    public EnemyIdleState(Enemy _enemy) : base(_enemy.gameObject){
        enemy = _enemy;
        //ObjToFollow = enemy.followPoint;
    }


    public override void Enter(){
        //enter anim
    }

    public override Type Tick() {
        if(!enemy.isInPlayerRadius){
           return(typeof(EnemyFollowState));
        }
        //do idle anim
        return null;
    }

    public override void Exit(){
        //exit anim
    }
}
