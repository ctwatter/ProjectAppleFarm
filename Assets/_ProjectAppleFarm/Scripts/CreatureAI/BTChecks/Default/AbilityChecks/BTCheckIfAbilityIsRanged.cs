using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTCheckIfAbilityIsRanged : BTChecker
{
    public BTCheckIfAbilityIsRanged(string _name, CreatureAIContext _context) : base(_name, _context)
    {
        name = _name;
        context = _context;
    }

    public override NodeState Evaluate()
    {
        if(context.lastTriggeredAbility >= 0){
            if(context.CD.abilities[context.lastTriggeredAbility] is creatureAttackRanged){
                return NodeState.SUCCESS;
            }
        }
        return NodeState.FAILURE;
    }
}
