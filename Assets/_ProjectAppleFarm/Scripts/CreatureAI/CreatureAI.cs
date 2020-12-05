using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureAI : MonoBehaviour
{
    public BTnode behaviorTree;
    private CreatureAIContext context;

    private void Start()
    {
        context = GetComponent<CreatureAIContext>();
        BuildBT();
    }

    private void Update() {
        behaviorTree.Evaluate();
        
    }


    private void FixedUpdate() {
        //behaviorTree.Evaluate();
    }
    //build the behavior tree for the creature
    private void BuildBT() 
    {
        List<BTnode> RootList = new List<BTnode>();

        #region BONDED FOLLOW PLAYER
            List<BTnode> BondedFollowPlayer = new List<BTnode>();
        
            #region bonded follow idle sequence
                List<BTnode> BondedIdleFollowList = new List<BTnode>();
                BTCheckInPlayerRadius inRadius = new BTCheckInPlayerRadius("In Player Radius", context);
                BTActionFollowIdle followIdle = new BTActionFollowIdle("Follow Idle", context);
                BondedIdleFollowList.Add(inRadius);
                BondedIdleFollowList.Add(followIdle);
                BTSequence followPlayerIdle = new BTSequence("Follow Player Idle", BondedIdleFollowList);
            #endregion

            #region bonded trail player sequence
                List<BTnode> BondedTrailPlayerList = new List<BTnode>();
                BTCheckInPlayerTrail inTrail = new BTCheckInPlayerTrail("In Player Trail", context);
                BTActionTrailPlayer trailPlayer = new BTActionTrailPlayer("Trail Player", context);
                BondedTrailPlayerList.Add(inTrail);
                BondedTrailPlayerList.Add(trailPlayer);
                BTSequence followPlayerTrail = new BTSequence("Follow Player Trail", BondedTrailPlayerList);
            #endregion
            
            #region bonded get closer to player selector
                List<BTnode> BondedGetCloserToPlayerList = new List<BTnode>();
                BTActionFollowPlayer followPlayerAction = new BTActionFollowPlayer("Follow Player", context);
                BTActionFollowTP followPlayerTP = new BTActionFollowTP("Follow Player TP", context);
                BondedGetCloserToPlayerList.Add(followPlayerAction);
                BondedGetCloserToPlayerList.Add(followPlayerTP);
                BTSelector followPlayerSelector = new BTSelector("Get Closer To Player", BondedGetCloserToPlayerList);
            #endregion
            
            BondedFollowPlayer.Add(followPlayerIdle);
            BondedFollowPlayer.Add(followPlayerTrail);
            BondedFollowPlayer.Add(followPlayerSelector);

            BTSelector bondedFollowPlayerSelector = new BTSelector("Bonded Follow Player", BondedFollowPlayer);
        #endregion

        #region CREATURE ABILITIES
            #region player triggered ability sequence        
                List<BTnode> AbilityTriggeredSequenceList = new List<BTnode>();

                #region Ability Selector
                    List<BTnode> AbilitySelectorList = new List<BTnode>();
                    BTActionAbilityFail AbilityFailsafe = new BTActionAbilityFail("Ability Failsafe", context);
                    #region MeleeAbilitySequence
                        List<BTnode> MeleeAbilitySequenceList = new List<BTnode>();
                        #region if target already exists selector
                            List<BTnode> TargetExistsSelectorList = new List<BTnode>();
                            BTCheckIfTargetExists checkIfTargetExists = new BTCheckIfTargetExists("Check if enemy already targeted", context);
                            BTActionFindTargetEnemy findTargetEnemy = new BTActionFindTargetEnemy("Find Closest Enemy in Range", context);
                            TargetExistsSelectorList.Add(checkIfTargetExists);
                            TargetExistsSelectorList.Add(findTargetEnemy);

                            BTSequence TargetExistsSelector = new BTSequence("Target Exists Selector", TargetExistsSelectorList);
                        #endregion 

                        #region Approach/Attack sequence
                            List<BTnode> MeleeApproachAttackSequenceList = new List<BTnode>();
                            BTActionApproachForAttack approachForAttack = new BTActionApproachForAttack("Approach for attack", context);
                            BTActionAttackMelee attackMelee = new BTActionAttackMelee("Melee Attack", context);
                            MeleeApproachAttackSequenceList.Add(approachForAttack);
                            MeleeApproachAttackSequenceList.Add(attackMelee);

                            BTSequence MeleeApproachAttackSequence = new BTSequence("Melee Approach / Attack Sequence", MeleeApproachAttackSequenceList);
                        #endregion

                        BTCheckIfAbilityIsMelee ifAbilityIsMelee = new BTCheckIfAbilityIsMelee("check if ability is melee", context);
                        MeleeAbilitySequenceList.Add(ifAbilityIsMelee);
                        MeleeAbilitySequenceList.Add(TargetExistsSelector);
                        MeleeAbilitySequenceList.Add(MeleeApproachAttackSequence);
                        MeleeAbilitySequenceList.Add(AbilityFailsafe);
                        BTSequence MeleeAbilitySequence = new BTSequence("Melee Ability Sequence", MeleeAbilitySequenceList);

                    #endregion

                    #region RangedAbilitySequence

                        #region if target already exists selector
                        
                        #endregion 

                        #region Approach/Attack sequence
                        
                        #endregion

                    #endregion

                    #region UtilityAbilitySequence

                        #region if target already exists selector
                        
                        #endregion 

                        #region Approach/Attack sequence
                        
                        #endregion

                    #endregion
                    
                    AbilitySelectorList.Add(MeleeAbilitySequence);
                    AbilitySelectorList.Add(AbilityFailsafe);

                    BTSelector AbilitySelector = new BTSelector("Ability Selector", AbilitySelectorList);
                #endregion
                BTCheckPlayerTriggeredAbility ifPlayerTriggeredAbility = new BTCheckPlayerTriggeredAbility("if player triggered ability", context);
                AbilityTriggeredSequenceList.Add(ifPlayerTriggeredAbility);
                AbilityTriggeredSequenceList.Add(AbilitySelector);

                BTSequence AbilityTriggeredSequence = new BTSequence("Ability Triggered Sequence", AbilityTriggeredSequenceList);
            #endregion
        #endregion


        #region WILD PLAYER
            #region wild player scary
                List<BTnode> WildPlayerScaryList = new List<BTnode>();
                BTCheckWildPlayerScary playerScary = new BTCheckWildPlayerScary("Player Scary", context);
                BTActionWildRunFromPlayer runFromPlayer = new BTActionWildRunFromPlayer("Run From Player", context);
                WildPlayerScaryList.Add(playerScary);
                WildPlayerScaryList.Add(runFromPlayer);
                BTSequence playerScarySequence = new BTSequence("Is Player Scary", WildPlayerScaryList);
            #endregion

            #region wild approach player
                List<BTnode> WildApproachPlayerList = new List<BTnode>();
                BTActionWildApproachPlayer approachPlayer = new BTActionWildApproachPlayer("Approach Player", context);
                //also adding idle
                WildApproachPlayerList.Add(playerScarySequence);
                WildApproachPlayerList.Add(approachPlayer);
                WildApproachPlayerList.Add(followIdle);
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

        //add this section later
        #region WILD NO PLAYER
            List<BTnode> WildNoPlayerList = new List<BTnode>();

            #region wild enemies nearby
                List<BTnode> WildEnemiesList = new List<BTnode>();
                BTCheckWildEnemiesInRange wildEnemies = new BTCheckWildEnemiesInRange("Are Enemies Nearby?", context);
                BTActionWildRunFromEnemies wildRunEnemy = new BTActionWildRunFromEnemies("Run From Enemies", context);
                WildEnemiesList.Add(wildEnemies);
                WildEnemiesList.Add(wildRunEnemy);
                BTSequence wildEnemySequence = new BTSequence("Wild Enemies Nearby", WildEnemiesList);
            #endregion

            #region wild wander
                List<BTnode> WildWanderList = new List<BTnode>();
                BTActionWildWanderInLocation wildWander = new BTActionWildWanderInLocation("Wander", context);
                BTActionWildWanderIdle wildWanderIdle = new BTActionWildWanderIdle("Wander Idle", context);
                WildWanderList.Add(wildWander);
                WildWanderList.Add(wildWanderIdle);
                BTSelector wildWanderSelector = new BTSelector("Wild Wander", WildWanderList);
            #endregion

            WildNoPlayerList.Add(wildEnemySequence);
            WildNoPlayerList.Add(wildWanderSelector);
            BTSelector wildNoPlayerSelector = new BTSelector("Wild No Player", WildNoPlayerList);
        #endregion

        #region IS CREATURE WILD
            #region creature is wild
                List<BTnode> CreatureIsWildList = new List<BTnode>();
                CreatureIsWildList.Add(noticedSequence);
                //be sure to add the no player section later
                CreatureIsWildList.Add(wildNoPlayerSelector); //placeholder for wild w/ no player section

                BTSelector creatureIsWildSelector = new BTSelector("Creature Is Wild", CreatureIsWildList);
            #endregion

            #region is creature wild
                List<BTnode> IsCreatureWildList = new List<BTnode>();
                BTCheckIsWild isWild = new BTCheckIsWild("Is Wild?", context);
                IsCreatureWildList.Add(isWild);
                IsCreatureWildList.Add(creatureIsWildSelector);
                BTSequence isCreatureWildSequence = new BTSequence("Is Creature Wild?", IsCreatureWildList);
            #endregion
        #endregion

        #region creature isnt wild selector
            List<BTnode> CreatureIsntWildSelectorList = new List<BTnode>();
            CreatureIsntWildSelectorList.Add(AbilityTriggeredSequence);
            CreatureIsntWildSelectorList.Add(bondedFollowPlayerSelector);

            BTSelector CreatureIsntWildSelector = new BTSelector("Creature isnt Wild Selector", CreatureIsntWildSelectorList);
        #endregion

        #region ROOT
            RootList.Add(isCreatureWildSequence);
            RootList.Add(CreatureIsntWildSelector);

            BTSelector _root = new BTSelector("Root", RootList);
        #endregion
        behaviorTree = _root;
    }

}
