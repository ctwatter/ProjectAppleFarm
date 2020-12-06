﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTCheckIfAbilityIsUtility : BTChecker
{
    public BTCheckIfAbilityIsUtility(string _name, CreatureAIContext _context) : base(_name, _context)
    {
        name = _name;
        context = _context;
    }

    public override NodeState Evaluate()
    {
        if(context.lastTriggeredAbility >= 0){
            if(context.CD.abilities[context.lastTriggeredAbility] is creatureAttackUtility){
                return NodeState.SUCCESS;
            }
        }
        return NodeState.FAILURE;
    }
}
