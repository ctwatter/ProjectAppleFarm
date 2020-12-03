using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTCheckIfTargetExists : BTChecker
{
    public BTCheckIfTargetExists(string _name, CreatureAIContext _context) : base(_name, _context)
    {
        name = _name;
        context = _context;
    }

    public override NodeState Evaluate()
    {
        if(context.targetEnemy == null){
            return NodeState.FAILURE;
        }
        return NodeState.SUCCESS;
    }
}
