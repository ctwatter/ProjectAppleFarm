using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class wildCreatureRunState : wildCreatureStateBase
{
    // Start is called before the first frame update
    private wildCreature wildCreature;
    

    public wildCreatureRunState(wildCreature _wildCreature) : base(_wildCreature.gameObject) {
        wildCreature = _wildCreature;
    }

    public override void Enter()
    {
        Debug.Log("run state");
       wildCreature.scared = false;
    }

    public override Type Tick()
    {
        if(!wildCreature.playerInRadius) {
            return typeof(wildCreatureWanderState);
        }
        transform.rotation = Quaternion.LookRotation(transform.position - wildCreature.player.transform.position);
        wildCreature.rigidbody.velocity = (transform.rotation * Vector3.forward) * wildCreature.runawaySpeed ;
        return null;
    }

    public override void Exit()
    {
       
    }
}
