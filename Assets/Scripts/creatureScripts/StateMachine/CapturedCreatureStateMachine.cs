//Author : Colin
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class CapturedCreatureStateMachine : MonoBehaviour
{
    private Dictionary<Type, CapturedCreatureBaseState> availableStates;

    public CapturedCreatureBaseState currState {get; private set; }
    public event Action<CapturedCreatureBaseState> OnStateChanged;

    public void SetStates(Dictionary<Type, CapturedCreatureBaseState> states){
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

    private void SwitchToNewState(Type nextState){
        
        currState.Exit();
        currState = availableStates[nextState];
        currState.Enter();
        OnStateChanged?.Invoke(currState); //??
    }
}
