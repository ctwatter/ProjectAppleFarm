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
            SetDefaultState( fsm.Slash0 );
        }

        public override void OnStateUpdate()
        {
            if(player.playerDash)
            {
                SetState( fsm.Dash );
                return;
            }
        }

        public override void OnStateFixedUpdate()
        {
            
        }

        public override void OnStateExit()
        {
            
        }
    }
}