using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTActionTrailPlayer : BTLeaf
{
    public BTActionTrailPlayer(string _name, CreatureAIContext _context) : base(_name, _context) {
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
        Debug.Log("Exiting Trail");
    }

    public override NodeState Evaluate()
    {
        if(!ranOnEnter){
            OnEnter();
        }
        Quaternion desiredLook = context.player.transform.rotation;
        context.doRotation(10f, desiredLook);
        context.doMovement(context.CD.moveSpeed);

        if(Vector3.Distance(context.player.transform.position, context.creatureTransform.position) > 20){
            // Player too far away
            OnExit();
            return NodeState.FAILURE;
        } else if(context.isInPlayerRadius){
            // Made it to player
            OnExit();
            return NodeState.SUCCESS;
        } else{
            // Still trying to get to player
            return NodeState.RUNNING;
        }
    }


}