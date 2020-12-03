﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTActionFindTargetEnemy : BTLeaf
{
    
    public BTActionFindTargetEnemy(string _name, CreatureAIContext _context ) : base(_name, _context){
        name = _name;
        context = _context;
    }

    protected override void OnEnter()
    {
        ranOnEnter = true;
        //set agent movespeed to faster
        //
    }

    protected override void OnExit()
    {
        ranOnEnter = false;
    }

    public override NodeState Evaluate() {
        if(!ranOnEnter){
            OnEnter();
        }
        
        int layermask = 1 << 8; //only layer 8 will be targeted
        Collider[] hitColliders = Physics.OverlapSphere(context.creatureTransform.position, context.enemyDetectRange, layermask);
        foreach (var hitCollider in hitColliders)
        { 
            Debug.Log("HIT ENEMY");
            context.targetEnemy = hitCollider.gameObject;
            return NodeState.SUCCESS;
           
        }

        OnExit();
        return NodeState.FAILURE;

    }
}
