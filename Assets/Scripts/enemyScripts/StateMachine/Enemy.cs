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
    public GameObject followPoint;
    public Rigidbody rigidbody;
    public float enemyMoveSpeed = 10f;
    public float rotationSpeed = 10f;
    

    public bool isInTrail;
    public bool isInPlayerRadius;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
        InitializeStateMachine();

    }

    private void InitializeStateMachine(){
        var states = new Dictionary<Type, EnemyBaseState>(){
            {typeof(EnemyIdleState), new EnemyIdleState(this)},
            {typeof(EnemyFollowState), new EnemyFollowState(this)}
        };
        GetComponent<EnemyStateMachine>().SetStates(states);
    }

    
}
