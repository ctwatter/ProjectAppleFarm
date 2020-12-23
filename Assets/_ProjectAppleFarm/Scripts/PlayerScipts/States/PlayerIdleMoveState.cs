using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace PlayerState
{
    [Serializable]
    public class IdleMove : State
    {
        // Set fields here

        public override void OnStateEnter()
        {
            animator.OnIdle();
        }

        public override void OnStateUpdate()
        {
            /*
            if(player.playerDash){
                fsm.SetState( player.dashState );
                return;
            }
            if(player.playerBasicAttack) {
                //playerController.playerBasicAttack = false;
                fsm.SetState( player.slash0State );
                return;
            }
            if(player.playerHeavyAttack) {
                //playerController.playerBasicAttack = false;
                fsm.SetState( player.heavyChargeState );
                return;
            }
            */
        }

        public override void OnStateFixedUpdate()
        {
            player.doMovement(1f);
            player.doRotation(1f);
        }

        public override void OnStateExit()
        {
            
        }
    }
}