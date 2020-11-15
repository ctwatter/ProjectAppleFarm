using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wildCreatureWanderState : wildCreatureStateBase
{
    private wildCreature wildCreature;
    Quaternion newRotation;
    float startTime;
    float delay;

    public wildCreatureWanderState(wildCreature _wildCreature) : base(_wildCreature.gameObject) {
        wildCreature = _wildCreature;
        
    }

    public override void Enter()
    {
        Debug.Log("wander state");
        startTime = Time.time;
        delay = UnityEngine.Random.Range(wildCreature.wanderRange.x, wildCreature.wanderRange.y);
    }

    public override Type Tick()
    {
        if(wildCreature.playerInRadius) {
            if(wildCreature.playerController.currSpeed > wildCreature.playerSpeedToScare){
                Debug.Log("player speed :" + wildCreature.playerController.currSpeed + " scare value :" +wildCreature.playerSpeedToScare );
                wildCreature.scared = true;
            } else {
                wildCreature.interested = true;
            }
            //if player velocity > x - run away, else, interested;
        } 
        if(wildCreature.scared) {
            Debug.Log("going to run from wander");
            return typeof(wildCreatureRunState);
        }
        if(wildCreature.interested) {
            return typeof(wildCreatureInterestedState);
        }
       
        if(Time.time > startTime + delay){
            Quaternion temp = UnityEngine.Random.rotation;
            newRotation = new Quaternion(0, temp.y, 0, 1);
            startTime = Time.time;
            delay = UnityEngine.Random.Range(wildCreature.wanderRange.x, wildCreature.wanderRange.y);
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 5);
        wildCreature.rigidbody.velocity = (transform.rotation * Vector3.forward * wildCreature.wanderSpeed );

        //move towards destination
        return null;

    }

    public override void Exit()
    {
       
    }
}
