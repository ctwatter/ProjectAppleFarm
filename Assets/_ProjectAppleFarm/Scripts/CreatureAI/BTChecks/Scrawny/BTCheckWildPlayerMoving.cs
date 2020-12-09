//Enrico
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTCheckWildPlayerMoving : BTChecker
{

    public BTCheckWildPlayerMoving(string _name, CreatureAIContext _context) : base(_name, _context)
    {
        name = _name;
        context = _context;
    }

    public override NodeState Evaluate()
    {
        if (context.player.GetComponent<PlayerController>().currSpeed > 0)
            Debug.Log("Player is moving");
            return NodeState.SUCCESS;
        return NodeState.FAILURE;
    }
}
