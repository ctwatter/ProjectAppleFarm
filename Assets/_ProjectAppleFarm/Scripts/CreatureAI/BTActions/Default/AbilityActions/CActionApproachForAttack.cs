﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CActionApproachForAttack : BTLeaf
{

    private NavMeshAgent agent;
    creatureAttackBase attack;
    private float moveSpeed = 30f;
    private float maxDist;

    public CActionApproachForAttack(string _name, CreatureAIContext _context ) : base(_name, _context){
        name = _name;
        context = _context;
        agent = context.agent;
    }

    protected override void OnEnter()
    {

        ranOnEnter = true; 
        if(context.CD.abilities[context.lastTriggeredAbility] is creatureAttackMelee) {
            creatureAttackMelee _attack = (creatureAttackMelee) context.CD.abilities[context.lastTriggeredAbility];
            maxDist = _attack.maxDistanceToEnemy;
           
        } else if(context.CD.abilities[context.lastTriggeredAbility] is creatureAttackRanged) {
            creatureAttackRanged _attack = (creatureAttackRanged) context.CD.abilities[context.lastTriggeredAbility];   
            maxDist = _attack.maxDistanceToEnemy;
        }
        agent.speed = moveSpeed;
        // agent.stoppingDistance = attack.maxDistanceToEnemy;
    }

    protected override void OnExit()
    {
        ranOnEnter = false;
        agent.speed = context.CD.moveSpeed;
        agent.stoppingDistance = 1f;
        agent.ResetPath();
    }

    public override NodeState Evaluate() {
        if(!ranOnEnter){
            OnEnter();
        }

        //Debug.Log("APROACH FOR ATTACK");
        agent.destination = context.targetEnemy.transform.position;
        float distance = Vector3.Distance(context.creatureTransform.position, context.targetEnemy.transform.position);
        
        //Debug.Log("Distance : " + distance + " maxDist : " + attack.maxDistanceToEnemy);
        if(distance < maxDist){
            // Made it to player
            OnExit();
            return NodeState.SUCCESS;
        } else{
            // Still trying to get to player
            context.updateDebugText(name);
            return NodeState.RUNNING;
        }
    }
}
