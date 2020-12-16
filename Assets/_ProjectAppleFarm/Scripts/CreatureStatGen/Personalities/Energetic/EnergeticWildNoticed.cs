﻿//Eugene
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
                EnergeticBTCheckWildPlayerScary playerScary = new EnergeticBTCheckWildPlayerScary("ENERGETIC Player Scary", context);
                EnergeticBTActionWildRunFromPlayer runFromPlayer = new EnergeticBTActionWildRunFromPlayer("ENERGETIC Run From Player", context);
                WildPlayerScaryList.Add(playerScary);
                WildPlayerScaryList.Add(runFromPlayer);
                BTSequence playerScarySequence = new BTSequence("ENERGETIC Is Player Scary", WildPlayerScaryList);
            #endregion

            #region wild approach player
                List<BTnode> WildApproachPlayerList = new List<BTnode>();
                EnergeticBTActionWildWanderInLocation wildWander = new EnergeticBTActionWildWanderInLocation("ENERGETIC Wander", context);
                EnergeticBTActionWildWanderIdle wildWanderIdle = new EnergeticBTActionWildWanderIdle("ENERGETIC Wander Idle", context);
                WildApproachPlayerList.Add(playerScarySequence);
                WildApproachPlayerList.Add(wildWander);
                WildApproachPlayerList.Add(wildWanderIdle);
                BTSelector approachPlayerSelector = new BTSelector("ENERGETIC Run/Approach Player", WildApproachPlayerList);
            #endregion

            #region wild notice player
                List<BTnode> WildNoticePlayerList = new List<BTnode>();
                BTCheckWildPlayerInRadius playerNoticed = new BTCheckWildPlayerInRadius("ENERGETIC Is Player Noticed", context);
                WildNoticePlayerList.Add(playerNoticed);
                WildNoticePlayerList.Add(approachPlayerSelector);
                BTSequence noticedSequence = new BTSequence("ENERGETIC Player Is Noticed", WildNoticePlayerList);
            #endregion
        #endregion
        return noticedSequence;
    }
}
