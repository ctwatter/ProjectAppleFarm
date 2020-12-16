// Herman, Enrico

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureAnimator : MonoBehaviour
{
    public GameObject model;
    public Animator animator => model.GetComponent<Animator>();

    public void Move(Vector3 moveSpeed) {
        if(moveSpeed.magnitude > 0){
            animator.SetBool("Move", true);
        }
        else{
            animator.SetBool("Move", false);
        }
    }
    public void Jump() {
        animator.SetTrigger("jump");
    }
    public void Attack1(){
        animator.SetTrigger("Attack1");
    }
    public void LayDown(){
        animator.SetTrigger("LayDown");
    }
    public void Sit(){
        animator.SetTrigger("Sit");
    }
    public void Wave(){
        animator.SetTrigger("Wave");
    }
}
