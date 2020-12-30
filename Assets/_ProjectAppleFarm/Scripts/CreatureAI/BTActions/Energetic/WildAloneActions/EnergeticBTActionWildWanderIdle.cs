// Eugene
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergeticBTActionWildWanderIdle : BTLeaf
{
    public EnergeticBTActionWildWanderIdle(string _name, CreatureAIContext _context) : base(_name, _context) {
        name = _name;
        context = _context;
    }

    protected override void OnEnter()
    {
        ranOnEnter = true;
        context.wanderIdleTimer = 0;
        context.wanderIdling = true;
        context.wanderIdleDuration = Random.Range(0.5f, 1f);
    }

    protected override void OnExit()
    {
        ranOnEnter = false;
        context.wanderIdleTimer = 0;
        context.wanderIdling = false;
    }

    public override NodeState Evaluate()
    {
        if(!ranOnEnter){
            OnEnter();
        }

        context.doMovement(0);
        context.wanderIdleTimer += Time.deltaTime;
        if (context.wanderIdleTimer >= context.wanderIdleDuration) {
            OnExit();
            return NodeState.SUCCESS;
        }
        return NodeState.RUNNING;
    }
}