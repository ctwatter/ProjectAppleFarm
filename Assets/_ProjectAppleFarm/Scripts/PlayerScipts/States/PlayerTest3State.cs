using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace PlayerState
{
    [Serializable]
    public class Test3 : State
    {
        // Set fields here
        public Test3( PlayerStateMachine _fsm ) : base( _fsm )
        {
            parent = fsm.Test1;
        }

        public override void OnStateEnter()
        {
            Debug.Log("Entering Test3");
            SetDefaultState( fsm.Test4 );
        }

        public override void OnStateUpdate()
        {
            
        }

        public override void OnStateFixedUpdate()
        {
            
        }

        public override void OnStateExit()
        {
            Debug.Log("Exiting Test3");
        }
    }
}