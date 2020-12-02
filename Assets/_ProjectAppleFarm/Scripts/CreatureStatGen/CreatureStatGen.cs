﻿//COLIN
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureStatGen 
{
    public creatureData dataIn;
    public ActiveCreatureData dataOut;



    public float life;
    public float power;
    public float utility;
    public float dexterity;

    List<personality> finalPersonalities = new List<personality>();

    List<personality> PowerPersonalities = new List<personality>();
    List<personality> UtilityPersonalities = new List<personality>();
    List<personality> DexterityPersonalities = new List<personality>();
    
    //personality example. make a bunch of these, put them all in a list and do some logic :)
                                //personality( _name, _statModType, _basePercentage, _maxPercentage, _statModifierAmount ){
    personality Adventurous = new personality("Adventurous", statModifierType.POWER, 1.1f, 0.1f, 0.4f); //could pre write out all personalities we like
    


 

    void initPersonalities(){
        PowerPersonalities.Add(Adventurous);
    }

    void choosePersonalities(){
        foreach (personality personality in PowerPersonalities) {
            if(personality.calcChance(power, dataIn.powerRange.x, dataIn.powerRange.y)) {
                finalPersonalities.Add(personality);
                break;
            }
        }
        foreach (personality personality in UtilityPersonalities) {
            if(personality.calcChance(utility, dataIn.utilityRange.x, dataIn.utilityRange.y)) {
                finalPersonalities.Add(personality);
                break;
            }
        }
        foreach (personality personality in DexterityPersonalities) {
            if(personality.calcChance(dexterity, dataIn.dexterityRange.x, dataIn.dexterityRange.y)) {
                finalPersonalities.Add(personality);
                break;
            }
        }
    }

    public void generateStats(){
        initPersonalities();

        life = Random.Range(dataIn.lifeRange.x, dataIn.lifeRange.y);
        power = Random.Range(dataIn.powerRange.x, dataIn.powerRange.y);
        utility = Random.Range(dataIn.utilityRange.x, dataIn.utilityRange.y);
        dexterity = Random.Range(dataIn.dexterityRange.x, dataIn.dexterityRange.y);

        choosePersonalities();

        dataOut.maxLife = life;
        dataOut.power = (int) power;
        dataOut.utility = (int) utility;
        dataOut.dexterity = (int) dexterity;
        dataOut.personalities = finalPersonalities;
        dataOut.moveSpeed = dataIn.moveSpeed;

        chooseAbilities(); //pick moves from list of moves;

        dataOut.ready = true;
    }

    void chooseAbilities() {

    }

}


public class personality {


    public string personalityName; //personality name
    public statModifierType statModType1; //the stat that this personality will modify
    public statModifierType statModType2;
    public float basePercentage; //base chance that a creature can roll this personality
    public float maxPercentage;
    public float statModifierAmount1; // amount that this personality affects the stat.
    public float statModifierAmount2;

    public personality(string _name, statModifierType _statModType1, float _statModifierAmount1,  float _basePercentage, float _maxPercentage){
        personalityName = _name;
        statModType1 = _statModType1;
        statModifierAmount1 = _statModifierAmount1;
        basePercentage = _basePercentage;
        maxPercentage = _maxPercentage;
       
    }


    //second constructor for having multiple stat types.
    public personality(string _name, statModifierType _statModType1, float _statModifierAmount1, statModifierType _statModType2, float _statModifierAmount2, float _basePercentage, float _maxPercentage,){
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

public enum statModifierType {
    POWER, UTILITY, DEXTERITY, LIFE, BONDRATE
}