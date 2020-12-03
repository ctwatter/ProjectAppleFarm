using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTCheckIfAbilityIsMelee : BTChecker
{
    public BTCheckIfAbilityIsMelee(string _name, CreatureAIContext _context) : base(_name, _context)
    {
        name = _name;
        context = _context;
    }

    public override NodeState Evaluate()
    {
        if(context.lastTriggeredAbility > 0){
            if(context.CD.abilities[context.lastTriggeredAbility] is creatureAttackMelee){
                return NodeState.SUCCESS;
            }
        }
        
        return NodeState.FAILURE;
    }
}
