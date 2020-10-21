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
    // private NavMeshAgent agent;
    // private float moveSpeed = 3f;
    // private float angularSpeed = 90f; //deg/s
    // private float acceleration; //max accel units/sec^2


    public EnemyFollowState(Enemy _enemy) : base(_enemy.gameObject){
        enemy = _enemy;
        
        // agent = base.gameObject.GetComponent<NavMeshAgent>();
        // ObjToFollow = enemy.followPoint;
        // agent.autoBraking = true;
        // agent.autoRepath = true;
        // agent.angularSpeed = angularSpeed;
        // //agent.acceleration = acceleration;
        // agent.speed = moveSpeed;
        
    }



    public override void Enter(){
        //enter anim
    }

    public override Type Tick() {
        if(enemy.isInTrail){
            if(enemy.isInPlayerRadius){
                enemy.rigidbody.velocity = Vector3.zero;
                return typeof(EnemyIdleState);
            }
            Quaternion desiredLook = enemy.Player.transform.rotation;
            enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, desiredLook, Time.deltaTime * enemy.rotationSpeed);
            enemy.rigidbody.velocity = (enemy.transform.rotation * Vector3.forward * enemy.enemyMoveSpeed );
            //face player direction, try to get 
        } else if(enemy.isInPlayerRadius && !enemy.isInTrail) {
                Debug.Log("1");
                Quaternion desiredLook = new Quaternion(enemy.Player.transform.rotation.x, enemy.Player.transform.rotation.y, enemy.Player.transform.rotation.z, enemy.Player.transform.rotation.w);
                
                //enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, Quaternion.Inverse(desiredLook), Time.deltaTime * enemy.rotationSpeed);
                //enemy.rigidbody.velocity = (enemy.transform.rotation * Vector3.forward * enemy.enemyMoveSpeed  );
        } else {
                Debug.Log("2");
                Vector3 desiredLook = new Vector3(enemy.Player.transform.position.x, enemy.transform.position.y, enemy.Player.transform.position.z);
                enemy.transform.LookAt(desiredLook, Vector3.up);
                enemy.rigidbody.velocity = (enemy.transform.rotation * Vector3.forward * enemy.enemyMoveSpeed );
        }
     
        // //Debug.Log("doing follow state");
        // //base.gameObject.transform.LookAt(ObjToFollow.transform, Vector3.up);
        // Vector3 desiredPos = new Vector3(ObjToFollow.transform.position.x, base.gameObject.transform.position.y, ObjToFollow.transform.position.z);
        // agent.SetDestination(desiredPos);
        
        // if(base.gameObject.transform.position == desiredPos){
        //     Debug.Log("Path Complete");
        //     return(typeof(EnemyIdleState));
        // }
        // //agent.CalculatePath(ObjToFollow.transform.position, agent.path);
        // //calc target location
        
        // //move at speed
        
        return null;
    }

    public override void Exit(){
        //exit anim
    }
}

//float radius = 1;
//float theta = player.tranform.rotation.y
//y = ((radius * sin(theta) - player.transform.position.z )/ (radius * cos(theta) - player.transform.postion.x)) +
// (radius (player.transform.postion.z * cos(theta) - player.transform.postion.x * sin(theta)) / (radius * cos(theta) - player.transform.postion.x))