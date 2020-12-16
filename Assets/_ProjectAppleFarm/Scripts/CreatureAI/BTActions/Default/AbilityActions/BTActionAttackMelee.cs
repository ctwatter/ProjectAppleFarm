using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTActionAttackMelee : BTLeaf
{

    creatureAttackMelee attack;
    public BTActionAttackMelee(string _name, CreatureAIContext _context ) : base(_name, _context){
        name = _name;
        context = _context;
    }

    protected override void OnEnter()
    {
        ranOnEnter = true;
        attack = (creatureAttackMelee) context.CD.abilities[context.lastTriggeredAbility];
        //Play amim
        context.animator.Attack1();
    }

    protected override void OnExit()
    {
        ranOnEnter = false;
    }

    public override NodeState Evaluate() {
        if(!ranOnEnter){
            OnEnter();
        }
        
        

        context.targetEnemy.GetComponent<EnemyStats>().takeDamage(attack.baseDmg);
        context.targetEnemy = null;
        context.isAbilityTriggered = false;
        if(true) { //if animation done, have to add that 
            return NodeState.SUCCESS;
        }
        

    }

}
