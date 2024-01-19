using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placer : MonoBehaviour {
    public List<BattleCharacter> characters = new List<BattleCharacter>();
    public List<BattlePlayer> players = new List<BattlePlayer>();
    public List<BattleEnemy> enemies = new List<BattleEnemy>();

    void Start() {
        foreach (BattlePlayer p in characters) { 
            characters.Add(p);
        }

        foreach (BattleEnemy p in enemies) {
            characters.Add(p);
        }


    }
}