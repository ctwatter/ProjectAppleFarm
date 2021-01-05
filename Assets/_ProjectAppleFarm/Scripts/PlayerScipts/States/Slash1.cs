//Colin and Jamo
// Herman for animations
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

namespace PlayerState
{
    [Serializable]
    public class Slash1 : State
    {
        public Slash1( PlayerStateMachine _fsm ) : base( _fsm )
        {
            name = "Slash1";
            parent = fsm.ComboAttackState;
        }



        public override void OnStateEnter()
        {
            player.playerBasicAttack = false;  
            animator.Attack1();            
        }



        public override void OnStateUpdate()
        {
            if(!player.getIsAttackAnim())
            {
                player.setIsAttackAnim(false);

                if(player.playerBasicAttack)
                {
                    SetState(fsm.Slash2);
                    return;
                }

                animator.SetRun(false);

                if(!player.getIsFollowThroughAnim())
                {
                    animator.resetAllAttackAnims();

                    SetState(fsm.IdleMove);
                    return;
                }
            }
        }



        public override void OnStateFixedUpdate()
        {
            player.doMovement(0.3f);
            player.doRotation(0.6f);
        }



        public override void OnStateExit()
        {
            player.playerBasicAttack = false;
        }
    }
}
