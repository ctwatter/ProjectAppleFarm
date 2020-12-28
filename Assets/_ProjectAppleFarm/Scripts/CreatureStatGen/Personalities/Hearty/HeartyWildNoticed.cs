// Jake
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HeartyWildNoticed", menuName = "ScriptableObjects/BTSubtrees/Hearty/WildNoticed")]
public class HeartyWildNoticed : BTSubtree
{
    public override BTSequence BuildSequenceSubtree(CreatureAIContext context) {
        #region WILD PLAYER

            #region wild player dropped food
                List<BTNode> WildDroppedFoodList = new List<BTNode>();
                HeartyBTCheckWildDroppedFood droppedFood = new HeartyBTCheckWildDroppedFood("Player Dropped Food", context);
                HeartyBTActionWildApproachDroppedFood approachDroppedFood = new HeartyBTActionWildApproachDroppedFood("Approach Dropped Food", context);
                WildDroppedFoodList.Add(droppedFood);
                WildDroppedFoodList.Add(approachDroppedFood);
                BTSequence droppedFoodSequence = new BTSequence("Player Dropped Food", WildDroppedFoodList);
            #endregion

            #region wild player scary
                List<BTNode> WildPlayerScaryList = new List<BTNode>();
                BTActionWildRunFromPlayer runFromPlayer = new BTActionWildRunFromPlayer("Run From Player", context);
                BTActionFollowIdle followIdle = new BTActionFollowIdle("Follow Idle", context);
                WildPlayerScaryList.Add(droppedFoodSequence);
                WildPlayerScaryList.Add(runFromPlayer);
                WildPlayerScaryList.Add(followIdle);
                BTSelector approachFoodSelector = new BTSelector("Run/Approach Food", WildPlayerScaryList);
            #endregion

            #region wild notice player
                List<BTNode> WildNoticePlayerList = new List<BTNode>();
                BTCheckWildPlayerInRadius playerNoticed = new BTCheckWildPlayerInRadius("Is Player Noticed", context);
                WildNoticePlayerList.Add(playerNoticed);
                WildNoticePlayerList.Add(approachFoodSelector);
                BTSequence noticedSequence = new BTSequence("Player Is Noticed", WildNoticePlayerList);
            #endregion
        #endregion
        return noticedSequence;
    }
}
