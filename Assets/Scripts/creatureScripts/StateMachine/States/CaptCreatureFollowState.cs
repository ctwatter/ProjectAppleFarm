//Author : Colin
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CaptCreatureFollowState : CapturedCreatureBaseState
{

    private CaptCreature captCreature;
    private GameObject ObjToFollow;
    private float distanceToPlayer;
    private float wantedDistance;
    // private NavMeshAgent agent;
    // private float moveSpeed = 3f;
    // private float angularSpeed = 90f; //deg/s
    // private float acceleration; //max accel units/sec^2


    public CaptCreatureFollowState(CaptCreature _captCreature) : base(_captCreature.gameObject){
        captCreature = _captCreature;
        // agent = base.gameObject.GetComponent<NavMeshAgent>();
        // ObjToFollow = captCreature.followPoint;
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
        if(captCreature.isInTrail){
            if(captCreature.isInPlayerRadius){
                captCreature.rigidbody.velocity = Vector3.zero;
                return typeof(CaptCreatureIdleState);
            }
            captCreature.transform.rotation = captCreature.Player.transform.rotation;
            captCreature.rigidbody.velocity = (captCreature.transform.rotation * Vector3.forward * captCreature.creatureMoveSpeed );
            //face player direction, try to get 
        } else {
            if(captCreature.isInPlayerRadius) {
                Debug.Log("1");
                captCreature.transform.rotation = new Quaternion(captCreature.Player.transform.rotation.x, captCreature.Player.transform.rotation.y + 180f, captCreature.Player.transform.rotation.z, captCreature.Player.transform.rotation.w);
                captCreature.rigidbody.velocity = (captCreature.transform.rotation * Vector3.forward * captCreature.creatureMoveSpeed  );
            } else {
                Debug.Log("2");
                captCreature.transform.LookAt(captCreature.Player.transform, Vector3.up);
                captCreature.rigidbody.velocity = (captCreature.transform.rotation * Vector3.forward * captCreature.creatureMoveSpeed );
            }
        }
        
        
        
        
        
        
        
        
        // //Debug.Log("doing follow state");
        // //base.gameObject.transform.LookAt(ObjToFollow.transform, Vector3.up);
        // Vector3 desiredPos = new Vector3(ObjToFollow.transform.position.x, base.gameObject.transform.position.y, ObjToFollow.transform.position.z);
        // agent.SetDestination(desiredPos);
        
        // if(base.gameObject.transform.position == desiredPos){
        //     Debug.Log("Path Complete");
        //     return(typeof(CaptCreatureIdleState));
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