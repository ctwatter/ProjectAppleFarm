﻿// Jake
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AdventurousWildAlone", menuName = "ScriptableObjects/BTSubtrees/Adventurous/WildAlone")]
public class AdventurousWildAlone : BTSubtree
{
    public override BTSelector BuildSelectorSubtree(CreatureAIContext context) {
        #region WILD NO PLAYER
            List<BTnode> WildNoPlayerList = new List<BTnode>();

            #region wild enemies nearby
                List<BTnode> WildEnemiesList = new List<BTnode>();
                AdventurousBTCheckWildEnemiesInRange wildEnemies = new AdventurousBTCheckWildEnemiesInRange("Are Enemies Nearby?", context);
                BTActionWildRunFromEnemies wildRunEnemy = new BTActionWildRunFromEnemies("Run From Enemies", context);
                WildEnemiesList.Add(wildEnemies);
                WildEnemiesList.Add(wildRunEnemy);
                BTSequence wildEnemySequence = new BTSequence("Wild Enemies Nearby", WildEnemiesList);
            #endregion

            #region wild wander
                List<BTnode> WildWanderList = new List<BTnode>();
                AdventurousBTActionWildWanderInLocation wildWander = new AdventurousBTActionWildWanderInLocation("Wander", context);
                BTActionWildWanderIdle wildWanderIdle = new BTActionWildWanderIdle("Wander Idle", context);
                WildWanderList.Add(wildWander);
                WildWanderList.Add(wildWanderIdle);
                BTSelector wildWanderSelector = new BTSelector("Wild Wander", WildWanderList);
            #endregion

            WildNoPlayerList.Add(wildEnemySequence);
            WildNoPlayerList.Add(wildWanderSelector);
            BTSelector wildNoPlayerSelector = new BTSelector("Wild No Player", WildNoPlayerList);
        #endregion
        return wildNoPlayerSelector;
    }
}
