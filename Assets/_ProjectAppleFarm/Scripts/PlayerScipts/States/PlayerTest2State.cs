using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace PlayerState
{
    [Serializable]
    public class Test2 : State
    {
        // Set fields here
        public Test2( PlayerStateMachine _fsm ) : base( _fsm )
        {
            //SetParent( fsm.inputState );
        }

        public override void OnStateEnter()
        {
            Debug.Log("Entering Test2");
            SetDefaultState( fsm.Test6 );
        }

        public override void OnStateUpdate()
        {
            if(player.playerBasicAttack)
            {
                player.playerBasicAttack = false;
                SetState(fsm.Test5);
            }
        }

        public override void OnStateFixedUpdate()
        {
            
        }

        public override void OnStateExit()
        {
            Debug.Log("Exiting Test2");
        }
    }
}