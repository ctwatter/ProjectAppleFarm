using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personality : MonoBehaviour
{


    public string personalityName; //personality name
    public statModifierType statModType1; //the stat that this personality will modify
    public statModifierType statModType2;
    public float basePercentage; //base chance that a creature can roll this personality
    public float maxPercentage;
    public float statModifierAmount1; // amount that this personality affects the stat.
    public float statModifierAmount2;

    protected BTnode buildWildWithPlayerTree(CreatureAIContext context) {
        //DEFAULT BT SUBTREE
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
                BTActionFollowIdle followIdle = new BTActionFollowIdle("Follow Idle", context);
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
        return noticedSequence;
    }

    protected BTnode buildWildWithNoPlayerTree(CreatureAIContext context) {
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
        return wildNoPlayerSelector;
    }

    protected BTnode buildAbilityTree(CreatureAIContext context){
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

                            BTSelector TargetExistsSelector = new BTSelector("Target Exists Selector", TargetExistsSelectorList);
                        #endregion 

                        #region Approach sequence
                            List<BTnode> MeleeApproachSelectorList = new List<BTnode>();
                            //BTCheckDistanceToTarget checkIfDistanceToTarget = new BTCheckDistanceToTarget("Check if in range for attack", context);
                            BTActionApproachForAttack approachForAttack = new BTActionApproachForAttack("Approach for attack", context);
                            BTInverter invertApproachForAttack = new BTInverter("Invert Approach for Attack", approachForAttack);
                            BTActionAttackMelee attackMelee = new BTActionAttackMelee("Melee Attack", context);
                            //MeleeApproachSequenceList.Add(checkIfDistanceToTarget);
                            MeleeApproachSelectorList.Add(invertApproachForAttack);
                            MeleeApproachSelectorList.Add(attackMelee);
                            
                            BTSelector MeleeApproachAttackSequence = new BTSelector("Melee Approach / Attack Sequence", MeleeApproachSelectorList);
                        #endregion


                        BTCheckIfAbilityIsMelee ifAbilityIsMelee = new BTCheckIfAbilityIsMelee("check if ability is melee", context);
                        
                        MeleeAbilitySequenceList.Add(ifAbilityIsMelee);
                        MeleeAbilitySequenceList.Add(TargetExistsSelector);
                        MeleeAbilitySequenceList.Add(MeleeApproachAttackSequence);
                        //MeleeAbilitySequenceList.Add(MeleeAttackSequence);
                        //MeleeAbilitySequenceList.Add(AbilityFailsafe);
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
        return AbilityTriggeredSequence;
    }

    protected BTnode buildBondedFollowPlayer(CreatureAIContext context){
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
        return bondedFollowPlayerSelector;
    }

    public Personality(string _name, statModifierType _statModType1, float _statModifierAmount1,  float _basePercentage, float _maxPercentage){
        personalityName = _name;
        statModType1 = _statModType1;
        statModifierAmount1 = _statModifierAmount1;
        basePercentage = _basePercentage;
        maxPercentage = _maxPercentage;
       
    }


    //second constructor for having multiple stat types.
    public Personality(string _name, statModifierType _statModType1, float _statModifierAmount1, statModifierType _statModType2, float _statModifierAmount2, float _basePercentage, float _maxPercentage){
        personalityName = _name;
        statModType1 = _statModType1;
        statModifierAmount1 = _statModifierAmount1;
        statModType2 = _statModType2;
        statModifierAmount2 = _statModifierAmount2;
        basePercentage = _basePercentage;
        maxPercentage = _maxPercentage;
        
    }



    public bool calcChance(float roll, float minRoll, float MaxRoll) {
        float chance = linearMap(roll, minRoll, MaxRoll, basePercentage, maxPercentage);
        if (chance < Random.Range(0f,1f)){
            return true;
        } else {
            return false;
        }
    }

    public float linearMap(float value, float inputLow, float inputHigh, float outputLow, float outputHigh) {
        return outputLow + (outputHigh - outputLow) * (value - inputLow) / (inputHigh - inputLow);
    }

}
