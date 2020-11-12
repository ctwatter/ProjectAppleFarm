//Author : Colin
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CaptCreature : MonoBehaviour
{
    public CapturedCreatureStateMachine capturedCreatureStateMachine => GetComponent<CapturedCreatureStateMachine>();
    public GameObject Player;
    public PlayerController playerController;
    public creatureData creatureData;
    public GameObject followPoint;
    public Rigidbody rigidbody;
    public Animator animator;
    public float creatureMoveSpeed = 10f;
    public float rotationSpeed = 10f;
    
    public bool isAnimDone = false;
    public bool isInTrail;
    public bool isInPlayerRadius;
    public bool creatureAbility1 = false;
    public bool creatureAbility2 = false;

    

    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
        capturedCreatureStateMachine.enabled = true;
        playerController = Player.GetComponent<PlayerController>();
        InitializeStateMachine();

    }

    private void OnEnable() {
        rigidbody = GetComponent<Rigidbody>();
        capturedCreatureStateMachine.enabled = true;
        playerController = Player.GetComponent<PlayerController>();
        InitializeStateMachine();
    }

    private void InitializeStateMachine(){
        var states = new Dictionary<Type, CapturedCreatureBaseState>(){
            {typeof(CaptCreatureIdleState), new CaptCreatureIdleState(this)},
            {typeof(CaptCreatureFollowState), new CaptCreatureFollowState(this)},
            {typeof(CaptCreatureAttackState), new CaptCreatureAttackState(this)},
            {typeof(CaptCreatureRangeAttackState), new CaptCreatureRangeAttackState(this)}
        };
        GetComponent<CapturedCreatureStateMachine>().SetStates(states);
    }


    void OnAttack2(){
        //if(cooldown)
        creatureAbility1 = true;

    }
    
    
    void OnAttack3(){

        //if(cooldown)
        creatureAbility2 = true;

    }

    public void animationFinished(){
        isAnimDone = true;
    }

    public GameObject spawnProjectile(GameObject obj){

        return Instantiate(obj, transform.position, transform.rotation);
    }
    
}
