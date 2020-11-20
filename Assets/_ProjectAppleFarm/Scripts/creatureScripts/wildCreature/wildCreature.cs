using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class wildCreature : MonoBehaviour
{
    public wildCreatureStateMachine wildCreatureStateMachine => GetComponent<wildCreatureStateMachine>();
    public GameObject player;
    public PlayerController playerController;
    public Rigidbody rigidbody;

    public float playerSpeedToScare;
    public bool playerInRadius;
    public float wanderSpeed;
    public Vector2 wanderRange;
    public bool scared;
    public float runawaySpeed;

    public bool interested;
    public float cautiousApproach;

    public GameObject wildCreatureTrigger1;
    public GameObject wildCreatureTrigger2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake() {
        GetComponent<CapturedCreatureStateMachine>().enabled = false;
        rigidbody = GetComponent<Rigidbody>();
        playerController = player.GetComponent<PlayerController>();
        rigidbody = GetComponent<Rigidbody>();
        //capturedCreatureStateMachine.enabled = true;

        InitializeStateMachine();

    }

    private void InitializeStateMachine(){
        var states = new Dictionary<Type, wildCreatureStateBase>(){
            {typeof(wildCreatureWanderState), new wildCreatureWanderState(this)},
            {typeof(wildCreatureRunState), new wildCreatureRunState(this)},
             {typeof(wildCreatureInterestedState), new wildCreatureInterestedState(this)},

        };
        GetComponent<wildCreatureStateMachine>().SetStates(states);
    }

    public void befriend(){
        GetComponent<wildCreatureStateMachine>().enabled = false;
        GetComponent<CaptCreature>().enabled = true;
        wildCreatureTrigger1.SetActive(false);
        wildCreatureTrigger2.SetActive(false);
        //disable curr state machine
        //enable capt creature script
    }


}
