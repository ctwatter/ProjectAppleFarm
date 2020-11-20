//Author : Jake
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyReturnToHomeState : EnemyBaseState
{
    private Enemy enemy;
    private Vector3 spawnPoint => enemy.getSpawnPoint();
    private float rotationSpeed;

    public EnemyReturnToHomeState(Enemy _enemy) : base(_enemy.gameObject){
        enemy = _enemy;
    }

    public override void Enter(){
        //enter anim
    }

    public override Type Tick() {
        //If enemy is at spawnPoint, go to idle state
        if(enemy.isAtSpawnPoint()){
            // Debug.Log("Returning to idle");
            enemy.rigidbody.velocity = Vector3.zero;
            return typeof(EnemyIdleState); //Set to idle state
        } else {
                // Debug.Log("Returning to spawn point");
                Vector3 desiredLook = new Vector3(spawnPoint.x, spawnPoint.y, spawnPoint.z);
                enemy.transform.LookAt(desiredLook, Vector3.up);
                enemy.rigidbody.velocity = (enemy.transform.rotation * Vector3.forward * enemy.enemyMoveSpeed );
        }
        return null;
    }

    public override void Exit(){
        //exit anim
    }
}
