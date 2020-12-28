using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CaptCreatureRangeAttackState : CapturedCreatureBaseState
{
    private CaptCreature captCreature;
    private GameObject ObjToFollow;


    public CaptCreatureRangeAttackState(CaptCreature _captCreature) : base(_captCreature.gameObject){
        captCreature = _captCreature;
    }


    public override void Enter(){
        //enter anim
        // Debug.Log("creature Range attack enter");
        // captCreature.creatureAbility2 = false;
        // captCreature.animator.SetTrigger("attack2");
        // creatureAttackRanged attackInfo = captCreature.creatureData.attack2;
        
        // int layermask = 1 << 8; //only layer 8 will be targeted
        // Collider[] hitColliders = Physics.OverlapSphere(captCreature.transform.position, 20f, layermask);
        // foreach (var hitCollider in hitColliders)
        // { 
        //     Debug.Log("HIT ENEMY");
        //     GameObject projectile = captCreature.spawnProjectile(attackInfo.projectile);
        //     projectile.GetComponent<ProjectileScript>().setTarget(hitCollider.gameObject, attackInfo.projectileSpeed, attackInfo.baseDmg);
        //     break;
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
