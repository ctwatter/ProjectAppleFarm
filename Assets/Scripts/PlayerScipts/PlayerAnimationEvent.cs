using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvent : MonoBehaviour
{
    private PlayerAnimator playerAnimator => transform.parent.GetComponent<PlayerAnimator>();

    public void attackDone()
    {
        playerAnimator.attackDone();
    }

    public void followThroughDone()
    {
        playerAnimator.followThroughDone();
    }
}
