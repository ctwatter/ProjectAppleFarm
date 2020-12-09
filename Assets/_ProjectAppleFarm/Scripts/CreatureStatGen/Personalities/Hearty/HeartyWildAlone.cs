// Jake
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HeartyWildAlone", menuName = "ScriptableObjects/BTSubtrees/Hearty/WildAlone")]
public class HeartyWildAlone : BTSubtree
{
    public override BTSelector BuildSelectorSubtree(CreatureAIContext context) {
        #region WILD NO PLAYER
            List<BTnode> WildNoPlayerList = new List<BTnode>();

            #region wild enemies nearby
                List<BTnode> WildEnemiesList = new List<BTnode>();
                BTCheckWildEnemiesInRange wildEnemies = new BTCheckWildEnemiesInRange("Are Enemies Nearby?", context);
                BTActionWildRunFromEnemies wildAttackEnemy = new BTActionWildRunFromEnemies("Run From Enemies", context);
                WildEnemiesList.Add(wildEnemies);
                WildEnemiesList.Add(wildAttackEnemy);
                BTSequence wildEnemySequence = new BTSequence("Wild Enemies Nearby", WildEnemiesList);
            #endregion

            #region wild wander
                List<BTnode> WildWanderList = new List<BTnode>();
                HeartyBTActionWildPickUpFood findFood = new HeartyBTActionWildPickUpFood("Find Food", context);
                BTActionWildWanderInLocation wildWander = new BTActionWildWanderInLocation("Wander", context);
                BTActionWildWanderIdle wildWanderIdle = new BTActionWildWanderIdle("Wander Idle", context);
                WildWanderList.Add(findFood);
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
