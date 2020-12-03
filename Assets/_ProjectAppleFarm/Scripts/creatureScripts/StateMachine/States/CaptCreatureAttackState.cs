using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CaptCreatureAttackState : CapturedCreatureBaseState
{
    private CaptCreature captCreature;
    private GameObject ObjToFollow;


    public CaptCreatureAttackState(CaptCreature _captCreature) : base(_captCreature.gameObject){
        captCreature = _captCreature;
    }


    public override void Enter(){
        //enter anim
        // Debug.Log("creature attack enter");
        // captCreature.creatureAbility1 = false;
        // captCreature.animator.SetTrigger("attack1");
        // creatureAttackMelee attackInfo = captCreature.creatureData.attack1;
        
        // int layermask = 1 << 8; //only layer 8 will be targeted
        // Collider[] hitColliders = Physics.OverlapSphere(captCreature.transform.position, 5f, layermask);
        // foreach (var hitCollider in hitColliders)
        // { 
        //     Debug.Log("HIT ENEMY");
        //     hitCollider.gameObject.GetComponent<EnemyStats>().takeDamage(attackInfo.baseDmg);
        //     //hitCollider.gameObject.GetComponent<enemyData>().Something;
        // }
       
    }

    public override Type Tick() {
      
        if(!captCreature.animator.GetCurrentAnimatorStateInfo(0).IsTag("attack")) {
            captCreature.isAnimDone = false;
            Debug.Log("animation finished");
            return typeof(CaptCreatureFollowState);
        }
        //do idle anim
        return null;
    }

    public override void Exit(){
        //exit anim
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(captCreature.transform.position, 5);
    }
}
