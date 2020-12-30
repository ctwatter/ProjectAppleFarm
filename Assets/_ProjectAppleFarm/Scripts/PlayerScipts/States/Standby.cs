using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

namespace PlayerState
{
    [Serializable]
    public class Standby : State
    {
        // Set fields here
        public Standby( PlayerStateMachine _fsm ) : base( _fsm )
        {
            base.name = "Standby";
            //SetParent( fsm.inputState );
        }

        public override void OnStateEnter()
        {
            Debug.Log("Entering Standby");
            //SetDefaultState( fsm.Test3 );
        }

        public override void OnStateUpdate()
        {
            if(player.playerBasicAttack)
            {
                player.playerBasicAttack = false;
                //SetState(fsm.Test4);
            }
        }

        public override void OnStateFixedUpdate()
        {
          
        }

        public override void OnStateExit()
        {
            Debug.Log("Exiting Standby");
        }
    }
}

