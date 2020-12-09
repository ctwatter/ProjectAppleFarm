using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTBool : BTnode
{
    protected BTnode node;
    bool toCheck;

    public BTBool(string _name, bool _toCheck, BTnode node) : base(_name) {
        name = _name;
        this.node = node;
        toCheck = _toCheck;
    }

    public override NodeState Evaluate()
    {
        if(toCheck){
            return node.Evaluate();
        } else {
            return NodeState.FAILURE;
        }
    }   


    // public stateBasedDecision(stats) {
    //     //figure it out
    // }
}
