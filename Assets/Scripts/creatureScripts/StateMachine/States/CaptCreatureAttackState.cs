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
        //ObjToFollow = captCreature.followPoint;
    }


    public override void Enter(){
        //enter anim
        //captCreature.creatureData.attack1 -> ranged/melee ->
    }

    public override Type Tick() {

        //do idle anim
        return null;
    }

    public override void Exit(){
        //exit anim
    }
}
