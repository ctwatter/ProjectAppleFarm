//Author : Colin
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class CaptCreatureIdleState : CapturedCreatureBaseState
{
    private CaptCreature captCreature;
    private GameObject ObjToFollow;
    private NavMeshAgent agent;

    public CaptCreatureIdleState(CaptCreature _captCreature) : base(_captCreature.gameObject){
        captCreature = _captCreature;
        //ObjToFollow = captCreature.followPoint;
    }


    public override void Enter(){
        //enter anim
    }

    public override Type Tick() {
        if(captCreature.creatureAbility1 || captCreature.creatureAbility2){
            return(typeof(CaptCreatureAttackState));
        }
        if(!captCreature.isInPlayerRadius){
           return(typeof(CaptCreatureFollowState));
        }
        //do idle anim
        return null;
    }

    public override void Exit(){
        //exit anim
    }
}
