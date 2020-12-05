﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class CreatureAIContext : MonoBehaviour
{
    #region Behavior Tree Context

    [Header("Objects")]
    public GameObject player;
    public GameObject targetEnemy;
    public Transform creatureTransform;
    public Rigidbody rb;
    public ActiveCreatureData CD;
    public creatureData creatureTypeData;
    public NavMeshAgent agent;
    public GameObject backFollowPoint;
    public GameObject followPoint;
    
    [Header("Bools")]
    public bool isWild;
    public bool isInPlayerRadius;
    public bool isInPlayerTrail;
    public bool isNoticed;
    public bool isAbilityTriggered;
    public bool wanderIdling = false;

    [Header("Misc.Numbers")]
    public float playerSpeedToScare;
    public int lastTriggeredAbility;
    public float enemyDetectRange;
    public float wanderRadius; //how far from starting location the creature can wander
    public float wanderIdleDuration;
    public float wanderIdleTimer;
    public Vector3 wanderDestination;
    public Vector3 wildStartingLocation;


    #endregion

    private void Awake()
    {
        creatureTransform = transform;
        wildStartingLocation = creatureTransform.position;
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        if(true) {
            //for now we're generating a new set of stats every time
            CreatureStatGen test = new CreatureStatGen();
            test.dataIn = creatureTypeData;
            test.dataOut = CD;
            test.generateStats();
            CD = test.dataOut;
        }
    }

    private void FixedUpdate() {

    }


    public void doMovement(float moveSpeed){
        rb.velocity = (creatureTransform.transform.rotation * Vector3.forward * moveSpeed);
    }

    public void doRotation(float rotationSpeed, Quaternion desiredLook) {
        creatureTransform.rotation = Quaternion.Slerp(creatureTransform.rotation, desiredLook, Time.deltaTime * rotationSpeed); //10 is rotation speed - might want to change later
    }

    public void doLookAt(Vector3 position){
        creatureTransform.transform.LookAt(position, Vector3.up);
        rb.velocity = (creatureTransform.transform.rotation * Vector3.forward * CD.moveSpeed);
    }
}
