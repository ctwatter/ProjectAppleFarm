using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class PlayerStateMachine : MonoBehaviour
{


    private Dictionary<Type, PlayerBaseState> availableStates;

    public PlayerBaseState currState {get; private set; }
    public event Action<PlayerBaseState> OnStateChanged;

    public void SetStates(Dictionary<Type, PlayerBaseState> states){
        availableStates = states;
    }

    private void Update() {
        if(currState == null) {
            currState = availableStates.Values.First(); //first state is default
        }
        
        var nextState = currState?.Tick();

        if(nextState != null && nextState != currState?.GetType()) {
            SwitchToNewState(nextState);
        }

    }

    private void FixedUpdate() {
        currState.PhysicsTick();
    }

    private void SwitchToNewState(Type nextState){
        
        currState.Exit();
        currState = availableStates[nextState];
        currState.Enter();
        OnStateChanged?.Invoke(currState); //??
    }
}
