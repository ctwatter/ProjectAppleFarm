using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

namespace PlayerState
{
    [Serializable]
    public class Test1 : State
    {
        // Set fields here
        public Test1( PlayerStateMachine _fsm ) : base( _fsm )
        {
            base.name = "Test1";
            //SetParent( fsm.inputState );
        }

        public override void OnStateEnter()
        {
            Debug.Log("Entering Test1");
            SetDefaultState( fsm.Test3 );
        }

        public override void OnStateUpdate()
        {
            if(player.playerBasicAttack)
            {
                player.playerBasicAttack = false;
                SetState(fsm.Test4);
            }
        }

        public override void OnStateFixedUpdate()
        {
          
        }

        public override void OnStateExit()
        {
            Debug.Log("Exiting Test1");
        }
    }
}

