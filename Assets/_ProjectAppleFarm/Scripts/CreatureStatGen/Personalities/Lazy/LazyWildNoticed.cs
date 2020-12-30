﻿//Eugene
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LazyWildNoticed", menuName = "ScriptableObjects/BTSubtrees/Lazy/WildNoticed")]
public class LazyWildNoticed : BTSubtree
{
    public override BTSequence BuildSequenceSubtree(CreatureAIContext context) {
        //DEFAULT BT SUBTREE
        #region WILD PLAYER
            #region wild player scary
                List<BTnode> WildPlayerScaryList = new List<BTnode>();
                LazyBTCheckWildPlayerScary playerScary = new LazyBTCheckWildPlayerScary("Player Scary", context);
                LazyBTActionWildRunFromPlayer runFromPlayer = new LazyBTActionWildRunFromPlayer("Run From Player", context);
                WildPlayerScaryList.Add(playerScary);
                WildPlayerScaryList.Add(runFromPlayer);
                BTSequence playerScarySequence = new BTSequence("Is Player Scary", WildPlayerScaryList);
            #endregion

            #region wild approach player
                List<BTnode> WildApproachPlayerList = new List<BTnode>();
                LazyBTActionWildApproachPlayer approachPlayer = new LazyBTActionWildApproachPlayer("Approach Player", context);
                LazyBTActionWildWanderIdle wildWanderIdle = new LazyBTActionWildWanderIdle("Wander Idle", context);
                WildApproachPlayerList.Add(playerScarySequence);
                WildApproachPlayerList.Add(approachPlayer);
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