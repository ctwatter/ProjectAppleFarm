//Author : Colin
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Creature", menuName = "ScriptableObjects/CreatureData", order = 1)]
public class creatureData : ScriptableObject
{

    public float maxLife;
    public int level; //??

    public float atk;
    public float def;
    public float sAtk;
    public float sDef;
    public float atkSpeed;
    
    public float moveSpeed;

    public CreatureType CreatureType;
    public creatureAttackMelee attack1;
    public creatureAttackBase attack2;

}

public enum CreatureType { //Temp creature types
    Fire,
    Water,
    Earth,
    Lightning
};
