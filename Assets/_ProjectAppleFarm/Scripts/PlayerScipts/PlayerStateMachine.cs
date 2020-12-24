using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerController player;

    [Header("States")]
    public PlayerState.Input inputState = new PlayerState.Input( this );
    public PlayerState.Movement movementState = new PlayerState.Movement( this );
    public PlayerState.IdleMove idleMoveState = new PlayerState.IdleMove( this );

    public PlayerState.State currentState { get; private set; }

    private void Start()
    {
        player = GetComponent<PlayerController>();

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
