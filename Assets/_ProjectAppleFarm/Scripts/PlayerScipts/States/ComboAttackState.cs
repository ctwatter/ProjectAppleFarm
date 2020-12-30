using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace PlayerState
{
    [Serializable]
    public class ComboAttackState : State
    {
        public ComboAttackState( PlayerStateMachine _fsm ) : base( _fsm )
        {
            parent = fsm.InputState;
        }

        public override void OnStateEnter()
        {
            SetDefaultState( fsm.IdleMove );
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