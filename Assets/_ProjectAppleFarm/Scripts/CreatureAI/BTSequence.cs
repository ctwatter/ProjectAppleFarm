// Jake, Colin, Eugene, Riko
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTSequence : BTnode
{
    protected List<BTnode> nodes = new List<BTnode>();
    
    public BTSequence(string _name, List<BTnode> nodes) : base(_name) {
        name = _name;
        this.nodes = nodes;
    }
    
    public override NodeState Evaluate()
    {
        bool isAnyNodeRunning = false;
        foreach (var node in nodes)
        {
            switch (node.Evaluate())
            {
                case NodeState.RUNNING:
                    isAnyNodeRunning = true;
                    break;
                case NodeState.SUCCESS: //Do nothing because all must succeed
                    break;
                case NodeState.FAILURE: //Return Failure since one failed
                    _nodeState = NodeState.FAILURE;
                    return _nodeState;
                default:
                    break;
            }
        }
        // If it made it here, then it should either be running or it succeeded
        _nodeState = isAnyNodeRunning ? NodeState.RUNNING : NodeState.SUCCESS;
        return _nodeState;
    }
}
