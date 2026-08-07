using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : CombatUnit
{
    void Awake()
    {
        base.Awake();
        instance = this;
    }
    public static Hero instance;
    public Enemy currentlyTargetedEnemy;
    /*public void healButtonPressed()
    {
        HealAbility.abilityUsed(this, this);
    }*/

    public void finishAnimation()
    {
        // do something;
    }
}
