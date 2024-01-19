using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlayer : BattleCharacter {
    public enum Class { 
        WARRIOR,
        MAGE,
        CLERIC,
        RANGER
    }

    public Class _class { get; set; }
    public int level { get; set; }

    public void setBaseStats() {
        level = 1;
        switch (_class) {
            case Class.WARRIOR:
                warriorBaseStats();
                break;
            case Class.MAGE:
                mageBaseStats();
                break;
            case Class.CLERIC:
                clericBaseStats();
                break;
            case Class.RANGER:
                rangerBaseStats();
                break;
        }
    }

    public void warriorBaseStats() {
        health = 100;
        strength = 10;
        defense = 8;
        magic = 2;
        resistance = 3;
        speed = 5;
        luck = 6;
    }

    public void mageBaseStats() {
        health = 50;
        strength = 3;
        defense = 2;
        magic = 10;
        resistance = 5;
        speed = 4;
        luck = 5;
    }

    public void clericBaseStats() {
        health = 80;
        strength = 5;
        defense = 5;
        magic = 8;
        resistance = 6;
        speed = 5;
        luck = 8;
    }

    public void rangerBaseStats() {
        health = 70;
        strength = 7;
        defense = 4;
        magic = 4;
        resistance = 3;
        speed = 9;
        luck = 6;
    }
}