using System.Collections;
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
        player = GameObject.FindGameObjectWithTag("Player");
        followPoint = GameObject.FindGameObjectWithTag("FrontFollowPoint");
        backFollowPoint = GameObject.FindGameObjectWithTag("BackFollowPoint");
    }

    public void GetActiveCreatureData(){
        CD = GetComponent<ActiveCreatureData>();
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
