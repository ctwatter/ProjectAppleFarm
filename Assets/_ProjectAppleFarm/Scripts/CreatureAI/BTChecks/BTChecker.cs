using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTChecker : BTnode
{
    bool toCheck;

    public BTChecker(string _name, bool _toCheck) : base(_name) {
        name = _name;
        toCheck = _toCheck;
    }

    public override NodeState Evaluate()
    {
        if (toCheck) {
            return NodeState.SUCCESS;
        } else {
            return NodeState.FAILURE;
        }
    }
}
