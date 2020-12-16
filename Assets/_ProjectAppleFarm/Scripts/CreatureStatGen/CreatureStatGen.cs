//COLIN
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

    List<Personality> finalPersonalities = new List<Personality>();

    List<Personality> PowerPersonalities = new List<Personality>();
    List<Personality> UtilityPersonalities = new List<Personality>();
    List<Personality> DexterityPersonalities = new List<Personality>();
    
    //Personality example. make a bunch of these, put them all in a list and do some logic :)
                                //Personality( _name, _statModType, _basePercentage, _maxPercentage, _statModifierAmount ){
    //Personality Adventurous = new Personality("Adventurous", statModifierType.POWER, 1.1f, 0.1f, 0.4f); //could pre write out all personalities we like
    


 

    void initPersonalities(){
        
    }

    void choosePersonalities(){
        foreach (Personality Personality in PowerPersonalities) {
            if(Personality.calcChance(power, dataIn.powerRange.x, dataIn.powerRange.y)) {
                finalPersonalities.Add(Personality);
                break;
            }
        }
        foreach (Personality Personality in UtilityPersonalities) {
            if(Personality.calcChance(utility, dataIn.utilityRange.x, dataIn.utilityRange.y)) {
                finalPersonalities.Add(Personality);
                break;
            }
        }
        foreach (Personality Personality in DexterityPersonalities) {
            if(Personality.calcChance(dexterity, dataIn.dexterityRange.x, dataIn.dexterityRange.y)) {
                finalPersonalities.Add(Personality);
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



public enum statModifierType {
    POWER, UTILITY, DEXTERITY, LIFE, BONDRATE, NONE
}