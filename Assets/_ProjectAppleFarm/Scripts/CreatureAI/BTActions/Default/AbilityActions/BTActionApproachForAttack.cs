using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BTActionApproachForAttack : BTLeaf
{

    private NavMeshAgent agent;
     creatureAttackMelee attack;
    private float moveSpeed = 30f;

    public BTActionApproachForAttack(string _name, CreatureAIContext _context ) : base(_name, _context){
        name = _name;
        context = _context;
        agent = context.agent;
    }

    protected override void OnEnter()
    {

        ranOnEnter = true;
        attack = (creatureAttackMelee) context.CD.abilities[context.lastTriggeredAbility];
        agent.speed = moveSpeed;
        // agent.stoppingDistance = attack.maxDistanceToEnemy;
    }

    protected override void OnExit()
    {
        ranOnEnter = false;
        agent.speed = context.CD.moveSpeed;
        agent.stoppingDistance = 1f;
    }

    public override NodeState Evaluate() {
        if(!ranOnEnter){
            OnEnter();
        }


        agent.destination = context.targetEnemy.transform.position;
        float distance = Vector3.Distance(context.creatureTransform.position, context.targetEnemy.transform.position);
        
        //Debug.Log("Distance : " + distance + " maxDist : " + attack.maxDistanceToEnemy);
        if(distance < attack.maxDistanceToEnemy){
            // Made it to player
            OnExit();
            return NodeState.SUCCESS;
        } else{
            // Still trying to get to player
            return NodeState.RUNNING;
        }
    }
}
