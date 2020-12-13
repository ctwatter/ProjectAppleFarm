// Jake, Colin, Eugene, Riko
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTSelector : BTnode
{
    protected List<BTnode> nodes = new List<BTnode>();
    
    public BTSelector(string _name, List<BTnode> nodes) : base(_name) {
        name = _name;
        this.nodes = nodes;
    }
    
    public override NodeState Evaluate()
    {
        foreach (var node in nodes) 
        {
            switch (node.Evaluate())
            {
                case NodeState.RUNNING:
                    _nodeState = NodeState.RUNNING;
                    return _nodeState;
                case NodeState.SUCCESS:
                    _nodeState = NodeState.SUCCESS;
                    return _nodeState;
                case NodeState.FAILURE:
                    break;
                default:
                    break;
            }
        }
        //if it made it here, all children returned FAILURE
        _nodeState = NodeState.FAILURE;
        return _nodeState;
    }
}
