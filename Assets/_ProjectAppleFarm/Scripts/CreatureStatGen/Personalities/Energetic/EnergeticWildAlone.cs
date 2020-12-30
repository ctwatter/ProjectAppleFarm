﻿//Eugene
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnergeticWildAlone", menuName = "ScriptableObjects/BTSubtrees/Energetic/WildAlone")]
public class EnergeticWildAlone : BTSubtree
{
    public override BTSelector BuildSelectorSubtree(CreatureAIContext context) {
        #region WILD NO PLAYER
            List<BTnode> WildNoPlayerList = new List<BTnode>();

            #region wild enemies nearby
                List<BTnode> WildEnemiesList = new List<BTnode>();
                BTCheckWildEnemiesInRange wildEnemies = new BTCheckWildEnemiesInRange("ENERGETIC Are Enemies Nearby?", context);
                EnergeticBTActionWildRunFromEnemies wildRunEnemy = new EnergeticBTActionWildRunFromEnemies("ENERGETIC Run From Enemies", context);
                WildEnemiesList.Add(wildEnemies);
                WildEnemiesList.Add(wildRunEnemy);
                BTSequence wildEnemySequence = new BTSequence("ENERGETIC Wild Enemies Nearby", WildEnemiesList);
            #endregion

            #region wild wander
                List<BTnode> WildWanderList = new List<BTnode>();
                EnergeticBTActionWildWanderInLocation wildWander = new EnergeticBTActionWildWanderInLocation("ENERGETIC Wander", context);
                EnergeticBTActionWildWanderIdle wildWanderIdle = new EnergeticBTActionWildWanderIdle("ENERGETIC Wander Idle", context);
                WildWanderList.Add(wildWander);
                WildWanderList.Add(wildWanderIdle);
                BTSelector wildWanderSequence = new BTSelector("ENERGETIC Wild Wander", WildWanderList);
            #endregion

            WildNoPlayerList.Add(wildEnemySequence);
            WildNoPlayerList.Add(wildWanderSequence);
            BTSelector wildNoPlayerSelector = new BTSelector("ENERGETIC Wild No Player", WildNoPlayerList);
        #endregion
        return wildNoPlayerSelector;
    }
}