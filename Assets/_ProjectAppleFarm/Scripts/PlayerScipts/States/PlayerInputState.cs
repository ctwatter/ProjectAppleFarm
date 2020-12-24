using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace PlayerState
{
    [Serializable]
    public class Input : State
    {
        public Input( PlayerStateMachine _fsm ) : base( _fsm ) {}

        public override void OnStateEnter()
        {
            SetDefaultState( fsm.movementState );
        }

        public override void OnStateUpdate()
        {
            if(player.isHit)
            {
                player.isHit = false;

                SetState( fsm.hitState );
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