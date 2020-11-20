//Author : Jake
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/EnemyData", order = 1)]
public class enemyData : ScriptableObject
{

    public float maxLife;
    public int level; //??

    public float atk;
    public float def;
    public float sAtk;
    public float sDef;
    public float atkSpeed;
    
    public float moveSpeed;

    public EnemyType EnemyType;
    public enemyAttackBase attack1;
    public enemyAttackBase attack2;

}

public enum EnemyType { //Temp enemy types
    Fire,
    Water,
    Earth,
    Lightning
};
