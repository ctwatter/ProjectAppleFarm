using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsWild : BTLeaf
{
    public IsWild(string _name, CreatureAIContext _context) : base(_name, _context)
    {
        name = _name;
        context = _context;
    }

    public override NodeState Evaluate()
    {
        if (context.isWild)
            return NodeState.SUCCESS;
        return NodeState.FAILURE;
    }
}
