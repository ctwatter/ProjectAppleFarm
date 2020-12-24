using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace PlayerState
{
    [Serializable]
    public class Movement : State
    {
        // Set fields here
        public Movement()
        {
            SetParent( player.inputState );
        }

        public override void OnStateEnter()
        {
            SetState( player.idleMoveState );
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