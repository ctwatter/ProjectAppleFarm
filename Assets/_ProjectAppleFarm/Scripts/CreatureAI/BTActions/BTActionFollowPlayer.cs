using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTActionFollowPlayer : BTnode
{
    public BTActionFollowPlayer(string _name, Transform creature,  Transform target) : base(_name) {
        name = _name;
    }



    public override NodeState Evaluate()
    {

        return NodeState.RUNNING;
    }
}