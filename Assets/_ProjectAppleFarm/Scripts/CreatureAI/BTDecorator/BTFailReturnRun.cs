﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTFailReturnRun : BTnode
{
    protected BTnode node;
    
    public BTFailReturnRun(string _name, BTnode node) : base(_name) {
        name = _name;
        this.node = node;
    }
    
    public override NodeState Evaluate()
    {
        switch (node.Evaluate())
        {
            case NodeState.RUNNING:
                _nodeState = NodeState.RUNNING;
                break;
            case NodeState.SUCCESS:
                _nodeState = NodeState.FAILURE;
                break;
            case NodeState.FAILURE:
                _nodeState = NodeState.RUNNING;
                return _nodeState;
            default:
                break;
        }
        return _nodeState;
    }
}
