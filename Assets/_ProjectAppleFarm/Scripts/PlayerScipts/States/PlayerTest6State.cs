using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace PlayerState
{
    [Serializable]
    public class Test6 : State
    {
        public Test6( PlayerStateMachine _fsm ) : base( _fsm )
        {
            parent = fsm.Test2;
        }

        public override void OnStateEnter()
        {
            //SetState( fsm.idleMoveState );
            Debug.Log("Entering state 6");
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
            Debug.Log("Exiting state 6");
        }
    }
}