//Author : Colin
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Creature", menuName = "ScriptableObjects/CreatureData", order = 1)]
public class creatureData : ScriptableObject
{

    public float maxLife;
    public int level; //??

    public int power;
    public int utility;
    public int dexterity;
    
    public float moveSpeed;


    public Vector2 lifeRange = new Vector2(100, 150);

    public Vector2 powerRange = new Vector2(5,20);
    //not sure what these two will be called yet, but I think 3 stats is good
    public Vector2 utilityRange = new Vector2(5, 20); 
    public Vector2 dexterityRange = new Vector2(10, 30); //dexterity is place holder??


    public List<Personality> personalities = new List<Personality>();
    public List<creatureAttackBase> creatureAttacks = new List<creatureAttackBase>();


    public CreatureType CreatureType;
    public creatureAttackBase attack1;
    public creatureAttackBase attack2;

}

public enum CreatureType { //Temp creature types
    Fire,
    Water,
    Earth,
    Lightning
};
