using UnityEngine;
using System.Collections;
using System;

public class BTUntilFailure: BTnode
{
    protected BTnode node;
    
    public BTUntilFailure(string _name, BTnode node) : base(_name) {
        name = _name;
        this.node = node;
    }
    public override NodeState Evaluate()
    {
            if ((node.Evaluate()) == NodeState.FAILURE) // If given a success return
            {
                return NodeState.FAILURE;
            } else {
                
                return NodeState.RUNNING;
            }
    }

}