﻿//Author : Colin
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Creature Ranged Attack", menuName = "ScriptableObjects/CreatureAttacks/RangedAttack", order = 1)]
public class creatureAttackRanged : creatureAttackBase
{

    public float projectileSpeed;

    public GameObject projectile;

    public Animation anims;

    public float baseDmg;

}
