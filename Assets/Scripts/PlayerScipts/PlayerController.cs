//Author : Colin
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float speed = 1f;
    public float turnSpeed = 0.15f;
    Rigidbody rb;
    Vector2 movementVel;
    CharacterController charController;
    Vector3 v3Vel;
    
    
    
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //character controller 
        v3Vel = new Vector3(movementVel.x, 0, movementVel.y);
        charController.Move(v3Vel * speed * Time.deltaTime);
        if(movementVel != Vector2.zero) {
            transform.forward = Vector3.Slerp(transform.forward, v3Vel, Time.deltaTime * turnSpeed);
        }
        //manual movement
        // rb.velocity = new Vector3(movementVel.x * speed, rb.velocity.y, movementVel.y * speed );
        // // Quaternion lookRot = new Quaternion(Quaternion.LookRotation(movementVel).x ,Quaternion.LookRotation(movementVel).y ,0, Quaternion.LookRotation(movementVel).w);
        // // transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, turnSpeed);
        // if(rb.velocity != Vector3.zero)
        //     transform.rotation = Quaternion.LookRotation(rb.velocity);
    }

    void OnMovement(InputValue value){
        //Debug.Log(value.Get<Vector2>());
        movementVel = value.Get<Vector2>();
        movementVel.Normalize();
        
    }

    void OnInteract(){
    
    }

    void OnAttack1(){
        //basic attack
    }
    
    void OnAttack2(){
        //attack based on creature
    }

    void OnAttack3(){
        //attack based on creature
    }
}
