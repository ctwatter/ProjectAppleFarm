﻿// Jake
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTActionFollowPlayer : BTLeaf
{
    public BTActionFollowPlayer(string _name, CreatureAIContext _context) : base(_name, _context) {
        name = _name;
        context = _context;
    }

    protected override void OnEnter()
    {
        ranOnEnter = true;
    }

    protected override void OnExit()
    {
        ranOnEnter = false;
        context.doMovement(0f);
    }

    public override NodeState Evaluate()
    {
        if(!ranOnEnter){
            OnEnter();
        }
        Vector3 desiredLook = new Vector3(context.player.transform.position.x, context.creatureTransform.transform.position.y, context.player.transform.position.z);
        context.doLookAt(desiredLook);
        context.doMovement(context.CD.moveSpeed);

        if(Vector3.Distance(context.player.transform.position, context.creatureTransform.position) > 20){
            // Player too far away
            OnExit();
            return NodeState.FAILURE;
        } else if(context.isInPlayerRadius || context.isInPlayerTrail){
            // Made it to player
            OnExit();
            return NodeState.SUCCESS;
        } else{
            // Still trying to get to player
            return NodeState.RUNNING;
        }
    }
}