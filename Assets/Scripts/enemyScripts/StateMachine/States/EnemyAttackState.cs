﻿//Author: Jake
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyAttackState : EnemyBaseState
{
    private Enemy enemy;
    private GameObject ObjToFollow;

    public EnemyAttackState(Enemy _enemy) : base(_enemy.gameObject){
        enemy = _enemy;
        //ObjToFollow = enemy.followPoint;
    }

    public override void Enter(){
        //enter anim
        //enemy.enemyData.attack1 -> ranged/melee ->
    }

    public override Type Tick() {

        //do idle anim
        return null;
    }

    public override void Exit(){
        //exit anim
    }
}
