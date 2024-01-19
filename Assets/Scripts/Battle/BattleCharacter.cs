using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCharacter : MonoBehaviour {
    //core stats - might move these somewhere else
    public float health { get; set; }
    public float strength { get; set; }
    public float magic { get; set; }
    public float defense { get; set; }
    public float resistance { get; set; }
    public float speed { get; set; }
    public float luck { get; set; }
    //combat stats
    public int bAtk { get; set; }
    public int bDef { get; set; }
    public int bDdg { get; set; }
    public int bSpd { get; set; }
    public int bHit { get; set; }
    public int bCrit { get; set; }
}