//Colin and Jamo
// Herman for animations
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

namespace PlayerState
{
    //NOT BEING USED, UNTIL 4TH ATTACK ANIM MADE
    [Serializable]
    public class Slash3 : State
    {
        // Set fields here
        public Slash3( PlayerStateMachine _fsm ) : base( _fsm )
        {
            name = "Slash3";
            parent = fsm.ComboAttackState;
        }

        public override void OnStateEnter()
        {

        }

        public override void OnStateUpdate()
        {
            if(player.playerBasicAttack)
            {
                player.playerBasicAttack = false;
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
