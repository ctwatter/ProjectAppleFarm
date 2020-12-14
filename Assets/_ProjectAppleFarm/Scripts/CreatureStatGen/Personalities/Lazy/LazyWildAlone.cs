//Eugene
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LazyWildAlone", menuName = "ScriptableObjects/BTSubtrees/Lazy/WildAlone")]
public class LazyWildAlone : BTSubtree
{
    public override BTSelector BuildSelectorSubtree(CreatureAIContext context) {
        #region WILD NO PLAYER
            List<BTnode> WildNoPlayerList = new List<BTnode>();

            #region wild enemies nearby
                List<BTnode> WildEnemiesList = new List<BTnode>();
                LazyBTCheckWildEnemiesInRange wildEnemies = new LazyBTCheckWildEnemiesInRange("Are Enemies Nearby?", context);
                LazyBTActionWildRunFromEnemies wildRunEnemy = new LazyBTActionWildRunFromEnemies("Run From Enemies", context);
                WildEnemiesList.Add(wildEnemies);
                WildEnemiesList.Add(wildRunEnemy);
                BTSequence wildEnemySequence = new BTSequence("Wild Enemies Nearby", WildEnemiesList);
            #endregion

            #region wild wander
                List<BTnode> WildWanderList = new List<BTnode>();
                LazyBTActionWildWanderIdle wildWanderIdle = new LazyBTActionWildWanderIdle("Wander Idle", context);
                LazyBTActionWildWanderInLocation wildWander = new LazyBTActionWildWanderInLocation("Wander", context);
                WildWanderList.Add(wildWanderIdle);
                WildWanderList.Add(wildWander);
                BTSelector wildWanderSelector = new BTSelector("Wild Wander", WildWanderList);
            #endregion

            WildNoPlayerList.Add(wildEnemySequence);
            WildNoPlayerList.Add(wildWanderSelector);
            BTSelector wildNoPlayerSelector = new BTSelector("Wild No Player", WildNoPlayerList);
        #endregion
        return wildNoPlayerSelector;
    }
}
