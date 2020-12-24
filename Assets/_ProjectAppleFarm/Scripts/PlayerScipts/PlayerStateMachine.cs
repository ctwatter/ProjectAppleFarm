using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerController player;

    public PlayerState.Test1 Test1;
    public PlayerState.Test2 Test2;
    public PlayerState.Test3 Test3;
    public PlayerState.Test4 Test4;
    public PlayerState.Test5 Test5;
    public PlayerState.Test6 Test6;

    public PlayerState.Movement movementState;
    public PlayerState.IdleMove idleMoveState;

    public PlayerState.State currentState { get; private set; }
    public PlayerState.State transitionExitState { get; set; }

    private void Start()
    {
        player = GetComponent<PlayerController>();

        Test1 = new PlayerState.Test1( this );
        Test2 = new PlayerState.Test2( this );
        Test3 = new PlayerState.Test3( this );
        Test4 = new PlayerState.Test4( this );
        Test5 = new PlayerState.Test5( this );
        Test6 = new PlayerState.Test6( this );

        movementState = new PlayerState.Movement( this );
        idleMoveState = new PlayerState.IdleMove( this );

        SetState(Test1);
    }

    public void SetState( PlayerState.State state )
    {        
        currentState = state;
        currentState.OnStateEnter();
    }

    private void Update()
    {
        currentState.OnParentStateUpdate();
    }

    private void FixedUpdate()
    {
        currentState.OnParentStateFixedUpdate();
    }
}
