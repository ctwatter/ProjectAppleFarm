// Herman, Enrico

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureAnimator : MonoBehaviour
{
    public GameObject model;
    public Animator animator => model.GetComponent<Animator>();

    public void Jump() {
        animator.SetTrigger("jump");
    }
}
