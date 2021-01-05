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
    public class Slash2 : State
    {
        public Slash2( PlayerStateMachine _fsm ) : base( _fsm )
        {
            name = "Slash2";
            parent = fsm.ComboAttackState;
        }



        public override void OnStateEnter()
        {
            player.playerBasicAttack = false;  
            animator.Attack2();            
        }



        public override void OnStateUpdate()
        {
            if(!player.getIsAttackAnim())
            {
                player.setIsAttackAnim(false);

                if(player.playerBasicAttack)
                {
                    //SetState(fsm.Slash3);
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
