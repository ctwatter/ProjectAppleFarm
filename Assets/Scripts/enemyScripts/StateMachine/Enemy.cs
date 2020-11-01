//Author : Jake
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public EnemyStateMachine enemyStateMachine => GetComponent<EnemyStateMachine>();
    public GameObject Player;
    public enemyData enemyData;
    private Vector3 spawnPoint;
    public GameObject followPoint;
    public EnemyFollowPlayerRadiusTrigger attackArea;
    public Rigidbody rigidbody;
    public float enemyMoveSpeed = 10f;
    public float rotationSpeed = 10f;

    public float attackStoppingDistance;

    public Animator animator;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
        spawnPoint = transform.position;
        InitializeStateMachine();
    }

    private void InitializeStateMachine(){
        var states = new Dictionary<Type, EnemyBaseState>(){
            {typeof(EnemyIdleState), new EnemyIdleState(this)},
            {typeof(EnemyAttackState), new EnemyAttackState(this)},
            {typeof(EnemyFollowState), new EnemyFollowState(this)},
            {typeof(EnemyReturnToHomeState), new EnemyReturnToHomeState(this)}
        };
        GetComponent<EnemyStateMachine>().SetStates(states);
    }

    public bool isAtSpawnPoint(){
        if(Vector3.Distance(transform.position, spawnPoint) < 1){
            return true;
        } else {
            return false;
        }
    }

    public Vector3 getSpawnPoint(){
        return spawnPoint;
    }

    
}
