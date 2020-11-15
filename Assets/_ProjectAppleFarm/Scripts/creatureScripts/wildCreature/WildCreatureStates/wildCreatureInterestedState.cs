using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class wildCreatureInterestedState : wildCreatureStateBase
{
    // Start is called before the first frame update
    private wildCreature wildCreature;
    

    public wildCreatureInterestedState(wildCreature _wildCreature) : base(_wildCreature.gameObject) {
        wildCreature = _wildCreature;
    }

    public override void Enter()
    {
        Debug.Log("interested state");
       wildCreature.interested = false;
    }

    public override Type Tick()
    {
        if(wildCreature.playerController.currSpeed > wildCreature.playerSpeedToScare){
            wildCreature.scared = true;
        }
        if(wildCreature.scared) {
            return typeof(wildCreatureRunState);
        }
        if(!wildCreature.playerInRadius){
            return typeof(wildCreatureWanderState);
        }
        transform.LookAt(wildCreature.player.transform, Vector3.up);
        wildCreature.rigidbody.velocity = (transform.rotation * Vector3.forward * wildCreature.cautiousApproach);
        return null;
    }

    public override void Exit()
    {
       
    }
}
