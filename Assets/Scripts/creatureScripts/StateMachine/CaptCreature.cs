//Author : Colin
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CaptCreature : MonoBehaviour
{
    public CapturedCreatureStateMachine capturedCreatureStateMachine => GetComponent<CapturedCreatureStateMachine>();
    public GameObject Player;
    public creatureData creatureData;
    public GameObject followPoint;
    

    private void Awake() {
        InitializeStateMachine();

    }

    private void InitializeStateMachine(){
        var states = new Dictionary<Type, CapturedCreatureBaseState>(){
            {typeof(CaptCreatureIdleState), new CaptCreatureIdleState(this)},
            {typeof(CaptCreatureFollowState), new CaptCreatureFollowState(this)}
        };
        GetComponent<CapturedCreatureStateMachine>().SetStates(states);
    }

    
}
