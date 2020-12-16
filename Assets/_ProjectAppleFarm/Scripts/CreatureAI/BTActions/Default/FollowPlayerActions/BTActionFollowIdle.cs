// Enrico
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTActionFollowIdle : BTLeaf
{
    public BTActionFollowIdle(string _name, CreatureAIContext _context) : base(_name, _context) {
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
    }

    public override NodeState Evaluate()
    {
        Debug.Log("In Follow Idle");
        context.doMovement(0);
        context.cleverIgnoreItems = false;
        //honestly this took me like 2 years to figure out how tf do people do this
        return NodeState.SUCCESS;
    }
}