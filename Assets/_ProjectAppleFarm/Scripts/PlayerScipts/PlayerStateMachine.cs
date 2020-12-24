using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace PlayerState
{
    public abstract class State
    {
        public PlayerStateMachine fsm { get; set; }
        public PlayerController player { get; set; }
        public PlayerAnimator animator => player.animator;

        private State parent;

        public virtual void OnStateEnter() { }
        public virtual void OnStateUpdate() { }
        public virtual void OnStateFixedUpdate() { }
        public virtual void OnStateExit() { }

        public void SetParent( State state )
        {
            parent = state;
        }

        public void SetState( State state )
        {
            OnParentStateExit();
            fsm.SetState( state );
        }

        public void OnParentStateUpdate()
        {
            parent?.OnParentStateUpdate();
            OnStateUpdate();
        }
        public void OnParentStateFixedUpdate()
        {
            parent?.OnParentStateFixedUpdate();
            OnStateFixedUpdate();
        }
        private void OnParentStateExit()
        {
            OnStateExit();
            if ( fsm.currentState != this )
            {
                parent?.OnParentStateExit();
            }
        }

    }
}

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerController player;

    [Header("States")]
    public PlayerState.Input inputState = new PlayerState.Input();
    public PlayerState.Movement movementState = new PlayerState.Movement();
    public PlayerState.IdleMove idleMoveState = new PlayerState.IdleMove();

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
