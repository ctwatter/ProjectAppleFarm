//Author : Colin
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerStateMachine playerStateMachine => GetComponent<PlayerStateMachine>();
    public PlayerAnimator playerAnimator => GetComponent<PlayerAnimator>();

    public bool isAnimDone = false; 
    public float speed = 1f;
    public float turnSpeed = 0.15f;

    public float dashSpeed;
    public float dashTime;
    public float dashDelay = 1.2f;
    public float dashStart = 2;
    public int dashCount = 0;
    public bool isDashing = false;

    Rigidbody rb;
    Vector2 movementVel;
    CharacterController charController;
    public Vector3 v3Vel;
    Vector3 gravity;

    public float crouchModifier = 1;
    public bool playerBasicAttack;
    public bool playerDash;
    public bool playerInteract;
    public bool nearInteractable = false;
    public GameObject wildCreature = null;
    public float currSpeed;
    public CapsuleCollider swordCollider; 
    private void Awake() {
        InitializeStateMachine();
    }

    private void InitializeStateMachine(){
         var states = new Dictionary<Type, PlayerBaseState>(){
            {typeof(PlayerIdleState), new PlayerIdleState(this)},
            {typeof(BasicHitState_0), new BasicHitState_0(this)},
            {typeof(BasicHitState_1), new BasicHitState_1(this)},
            {typeof(BasicHitState_2), new BasicHitState_2(this)},
            {typeof(BasicHitState_3), new BasicHitState_3(this)},
            {typeof(PlayerDashState), new PlayerDashState(this)}
        };
        GetComponent<PlayerStateMachine>().SetStates(states);
    }
    
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        charController = GetComponent<CharacterController>();
        dashStart = Time.time;
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //character controller 
        //doMovement(1f);
        //doRotation(1f);
        //manual movement
        // rb.velocity = new Vector3(movementVel.x * speed, rb.velocity.y, movementVel.y * speed );
        // // Quaternion lookRot = new Quaternion(Quaternion.LookRotation(movementVel).x ,Quaternion.LookRotation(movementVel).y ,0, Quaternion.LookRotation(movementVel).w);
        // // transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, turnSpeed);
        // if(rb.velocity != Vector3.zero)
        //     transform.rotation = Quaternion.LookRotation(rb.velocity);
    }


    public void doMovement(float movementModifier){
        
        if(!isDashing)
        {
            v3Vel = new Vector3(movementVel.x, 0, movementVel.y);
        }
       
        

        if(!charController.isGrounded) {
            gravity += Physics.gravity * Time.deltaTime;
        } else{
            gravity = Vector3.zero;
        }
        currSpeed = (Mathf.Abs(v3Vel.x) + Mathf.Abs(v3Vel.z)) / 2 * speed * Time.deltaTime * movementModifier * crouchModifier;
        var movementVector = v3Vel * speed * Time.deltaTime * movementModifier * crouchModifier;
        charController.Move(movementVector);
        charController.Move(gravity * Time.deltaTime);

        playerAnimator.Move(movementVector);
    }

    public void doRotation(float rotationModifier){
        v3Vel = new Vector3(movementVel.x, 0, movementVel.y);
        if(movementVel != Vector2.zero) {
            transform.forward = Vector3.Slerp(transform.forward, v3Vel, Time.deltaTime * turnSpeed * rotationModifier);
        }
    }

    public void setRotation(Vector3 vec)
    {
        transform.forward = vec;
    }

    void OnMovement(InputValue value){
        //Debug.Log(value.Get<Vector2>());
        movementVel = value.Get<Vector2>();
        movementVel.Normalize();
        
    }

    //by Jamo
    //allow for no more than two dashes in rapid succession
    void OnInteract(){ //pressing dash button       
        if(nearInteractable) {
            playerInteract = true;
            if(wildCreature != null){
                wildCreature.GetComponent<wildCreature>().befriend();
                nearInteractable = false;
            }
        } else {
            if(Time.time > dashStart + dashDelay)//cant dash until more time than dash delay has elapsed,
            {
                //takes dash start time
                dashStart = Time.time;
                dashCount++;
                playerDash = true;
            }
            else if(dashCount >= 1 )//if you have dashed once and are not past delay, you can dash a second time
            {
                dashCount = 0;
                playerDash = true;          
                
            }   
        }
                 
    }

    void OnAttack1(){
        playerBasicAttack = true;
    }

    public void animationDone()
    {
        Debug.Log("Anim done");
        isAnimDone = true;  
    }

    void OnCrouch() {
        if(crouchModifier == 1f){
            crouchModifier = .5f;
        } else {
            crouchModifier = 1f;
        }
    }
    
}
