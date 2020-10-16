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
    private NavMeshAgent agent;
    private float moveSpeed = 3f;
    private float angularSpeed = 90f; //deg/s
    private float acceleration; //max accel units/sec^2


    public CaptCreatureFollowState(CaptCreature _captCreature) : base(_captCreature.gameObject){
        captCreature = _captCreature;
        agent = base.gameObject.GetComponent<NavMeshAgent>();
        ObjToFollow = captCreature.followPoint;
        agent.autoBraking = true;
        agent.autoRepath = true;
        agent.angularSpeed = angularSpeed;
        //agent.acceleration = acceleration;
        agent.speed = moveSpeed;
    }



    public override void Enter(){
        //enter anim
    }

    public override Type Tick() {
        //Debug.Log("doing follow state");
        //base.gameObject.transform.LookAt(ObjToFollow.transform, Vector3.up);
        Vector3 desiredPos = new Vector3(ObjToFollow.transform.position.x, base.gameObject.transform.position.y, ObjToFollow.transform.position.z);
        agent.SetDestination(desiredPos);
        
        if(base.gameObject.transform.position == desiredPos){
            Debug.Log("Path Complete");
            return(typeof(CaptCreatureIdleState));
        }
        //agent.CalculatePath(ObjToFollow.transform.position, agent.path);
        //calc target location
        
        //move at speed
        
        return null;
    }

    public override void Exit(){
        //exit anim
    }
}
