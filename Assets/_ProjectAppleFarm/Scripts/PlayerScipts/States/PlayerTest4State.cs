using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace PlayerState
{
    [Serializable]
    public class Test4 : State
    {
        // Set fields here
        public Test4( PlayerStateMachine _fsm ) : base( _fsm )
        {
            parent = fsm.Test3;
        }

        public override void OnStateEnter()
        {
            Debug.Log("Entering Test4");
            //SetState( fsm.idleMoveState );
        }

        public override void OnStateUpdate()
        {
            
        }

        public override void OnStateFixedUpdate()
        {
            
        }

        public override void OnStateExit()
        {
            Debug.Log("Exiting Test4");
        }
    }
}