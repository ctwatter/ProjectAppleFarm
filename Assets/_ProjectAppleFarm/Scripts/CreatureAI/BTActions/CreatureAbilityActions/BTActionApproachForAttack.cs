using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BTActionApproachForAttack : BTLeaf
{

    private NavMeshAgent agent;
     creatureAttackMelee attack;
    private float moveSpeed = 2f;

    public BTActionApproachForAttack(string _name, CreatureAIContext _context ) : base(_name, _context){
        name = _name;
        context = _context;
    }

    protected override void OnEnter()
    {

        ranOnEnter = true;
        attack = (creatureAttackMelee) context.CD.abilities[context.lastTriggeredAbility];
        agent.speed = moveSpeed;
        agent.stoppingDistance = attack.distanceToEnemy;
    }

    protected override void OnExit()
    {
        ranOnEnter = false;
        agent.speed = context.CD.moveSpeed;
        agent.stoppingDistance = 1f;
    }

    public override NodeState Evaluate() {
        agent.destination = context.targetEnemy.transform.position;

        if(agent.pathStatus == NavMeshPathStatus.PathInvalid){
            
            OnExit();
            return NodeState.FAILURE;
        } else if(agent.pathStatus == NavMeshPathStatus.PathComplete){
            // Made it to player
            OnExit();
            return NodeState.SUCCESS;
        } else{
            // Still trying to get to player
            return NodeState.RUNNING;
        }
    }
}
