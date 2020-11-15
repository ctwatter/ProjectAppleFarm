//Author : Jake
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowState : EnemyBaseState
{
    private Enemy enemy;
    private GameObject ObjToFollow;
    private float distanceToPlayer;
    private float wantedDistance;
    private float rotationSpeed;

   
    public EnemyFollowState(Enemy _enemy) : base(_enemy.gameObject){
        enemy = _enemy;
    }

    public override void Enter(){
        //enter anim
    }

    public override Type Tick() {
        if(enemy.isHit)
        {
            enemy.isHit = false;
            return typeof(EnemyIsHit);
        }
        else{
        //If player not in radius, move back to spawn point
            if(!(enemy.attackArea.isPlayerInRadius))
            {
                enemy.rigidbody.velocity = Vector3.zero;
                return typeof(EnemyReturnToHomeState);
            } 
            else 
            {
                //Chase player
                // Debug.Log("Chasing player");
                if(enemy.isAttacking == false)
                {
                Vector3 desiredLook = new Vector3(enemy.Player.transform.position.x, enemy.Player.transform.position.y, enemy.Player.transform.position.z);
                enemy.transform.LookAt(desiredLook, Vector3.up);
                enemy.rigidbody.velocity = (enemy.transform.rotation * Vector3.forward * enemy.enemyMoveSpeed );
                }

                //Set state to attackState once close enough
                // Debug.Log("Attacking player");
                if(Time.time > enemy.startTime + enemy.timeDelay)
                {
                    if(Vector3.Distance(enemy.transform.position, enemy.Player.transform.position) < enemy.attackStoppingDistance)
                    {
                        enemy.rigidbody.velocity = Vector3.zero;
                        return typeof(EnemyAttackState);
                    }
                }
            }
        }
        return null;
    }

    public override void Exit(){
        //exit anim
    }
}
