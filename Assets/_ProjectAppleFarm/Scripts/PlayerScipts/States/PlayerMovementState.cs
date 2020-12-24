using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace PlayerState
{
    [Serializable]
    public class Movement : State
    {
        public Movement( PlayerStateMachine _fsm ) : base( _fsm )
        {
            parent = fsm.inputState;
        }

        public override void OnStateEnter()
        {
            SetDefaultState( fsm.idleMoveState );
        }

        public override void OnStateUpdate()
        {
            
        }

        public override void OnStateFixedUpdate()
        {
            
        }

        public override void OnStateExit()
        {
            
        }
    }
}