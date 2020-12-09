using UnityEngine;
using System.Collections;
using System;

public class BTPersist: BTnode
{
    protected BTnode node;

    public BTPersist(string _name, BTnode node) : base(_name) {
        name = _name;
        this.node = node;
    }
    public override NodeState Evaluate()
    {
        return NodeState.RUNNING;
    }

}