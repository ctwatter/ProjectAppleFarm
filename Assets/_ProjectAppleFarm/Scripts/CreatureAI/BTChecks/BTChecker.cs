using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTChecker : BTnode
{
    //bool toCheck
    CreatureAIContext context;

    public BTChecker(string _name, CreatureAIContext _context) : base(_name) {
        name = _name;
        context = _context;
        //toCheck = _toCheck;
    }

    public override NodeState Evaluate()
    {
        /*
        if (toCheck) {
            return NodeState.SUCCESS;
        } else {
            return NodeState.FAILURE;
        }
        */

        return NodeState.SUCCESS;
    }
}
