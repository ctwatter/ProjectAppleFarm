//Eugene
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnergeticWildNoticed", menuName = "ScriptableObjects/BTSubtrees/Energetic/WildNoticed")]
public class EnergeticWildNoticed : BTSubtree
{
    public override BTSequence BuildSequenceSubtree(CreatureAIContext context) {
        //DEFAULT BT SUBTREE
        #region WILD PLAYER
            #region wild player scary
                List<BTnode> WildPlayerScaryList = new List<BTnode>();
                EnergeticBTCheckWildPlayerScary playerScary = new EnergeticBTCheckWildPlayerScary("Player Scary", context);
                EnergeticBTActionWildRunFromPlayer runFromPlayer = new EnergeticBTActionWildRunFromPlayer("Run From Player", context);
                WildPlayerScaryList.Add(playerScary);
                WildPlayerScaryList.Add(runFromPlayer);
                BTSequence playerScarySequence = new BTSequence("Is Player Scary", WildPlayerScaryList);
            #endregion

            #region wild approach player
                List<BTnode> WildApproachPlayerList = new List<BTnode>();
                EnergeticBTActionWildWanderInLocation wildWander = new EnergeticBTActionWildWanderInLocation("Wander", context);
                EnergeticBTActionWildWanderIdle wildWanderIdle = new EnergeticBTActionWildWanderIdle("Wander Idle", context);
                WildApproachPlayerList.Add(playerScarySequence);
                WildApproachPlayerList.Add(wildWander);
                WildApproachPlayerList.Add(wildWanderIdle);
                BTSelector approachPlayerSelector = new BTSelector("Run/Approach Player", WildApproachPlayerList);
            #endregion

            #region wild notice player
                List<BTnode> WildNoticePlayerList = new List<BTnode>();
                BTCheckWildPlayerInRadius playerNoticed = new BTCheckWildPlayerInRadius("Is Player Noticed", context);
                WildNoticePlayerList.Add(playerNoticed);
                WildNoticePlayerList.Add(approachPlayerSelector);
                BTSequence noticedSequence = new BTSequence("Player Is Noticed", WildNoticePlayerList);
            #endregion
        #endregion
        return noticedSequence;
    }
}
