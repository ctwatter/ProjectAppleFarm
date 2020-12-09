// Jake
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DaringBTActionAttackEnemies : BTLeaf
{
    private NavMeshAgent agent;
    private float moveSpeed = 5f;
    private float angularSpeed = 720f; //deg/s
    private float acceleration = 100f; //max accel units/sec^2

    public DaringBTActionAttackEnemies(string _name, CreatureAIContext _context) : base(_name, _context) {
        name = _name;
        context = _context;

        agent = context.agent;
        //ObjToFollow = captCreature.followPoint;
        agent.autoBraking = true;
        agent.autoRepath = false;
        agent.angularSpeed = angularSpeed;
        agent.acceleration = acceleration;
        agent.speed = moveSpeed;
    }

    protected override void OnEnter()
    {
        ranOnEnter = true;
    }

    protected override void OnExit()
    {
        ranOnEnter = false;
        context.doMovement(0f);
        agent.ResetPath();
    }

    public override NodeState Evaluate()
    {
        // Not sure how to make wild enemies attack lol

        if(!ranOnEnter){
            OnEnter();
        }

        Vector3 position_difference = context.creatureTransform.position - context.targetEnemy.transform.position;
        position_difference.Normalize();
        agent.destination = context.creatureTransform.position + position_difference * 10;

        if(Vector3.Distance(context.targetEnemy.transform.position, context.creatureTransform.position) > 10){
            // creature escaped player
            OnExit();
            return NodeState.SUCCESS;
        } else {
            // Still trying to get to player
            return NodeState.RUNNING;
        }
    }
}