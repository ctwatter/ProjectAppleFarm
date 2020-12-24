using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerController player;

    public PlayerState.Input inputState;
    public PlayerState.Movement movementState;
    public PlayerState.IdleMove idleMoveState;

    public PlayerState.State currentState { get; private set; }

    private void Start()
    {
        player = GetComponent<PlayerController>();

        inputState = new PlayerState.Input( this );
        movementState = new PlayerState.Movement( this );
        idleMoveState = new PlayerState.IdleMove( this );

        SetState(inputState);
    }

    public void SetState( PlayerState.State state )
    {        
        currentState = state;
        currentState.fsm = this;
        currentState.player = player;
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
