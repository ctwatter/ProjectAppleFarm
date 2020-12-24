using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace PlayerState
{
    [Serializable]
    public class Test5 : State
    {
        public Test5( PlayerStateMachine _fsm ) : base( _fsm )
        {
            parent = fsm.Test1;
        }

        public override void OnStateEnter()
        {
            Debug.Log("Entering state 5");
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
            Debug.Log("Exiting state 5");
        }
    }
}