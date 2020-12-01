using UnityEngine;
using System.Collections;
using System;

public class BTUntilSucceed : BTnode
{
    protected BTnode node;
    
    public BTUntilSucceed(string _name, BTnode node) : base(_name) {
        name = _name;
        this.node = node;
    }
    public override NodeState Evaluate()
    {
            if ((node.Evaluate()) == NodeState.SUCCESS) // If given a success return
            {
                return NodeState.SUCCESS;
            } else {
                
                return NodeState.RUNNING;
            }
            
    }

}