using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CombatUnit
{
    // NEXT UP, ANIMATIONS AND TURN HANDLING, AND GIVING THE ENEMY ACCESS TO ABILITIES. 
    void Awake()
    {
        base.Awake();
    }

    public void preformEnemyAIAction()
    {
        ButtonManager.abilityDictionary[CombatAbility.AbilitySelected.BASICATTACK].abilityUsed(this, Hero.instance);
        TurnManager.transferControl(Hero.instance);
    }

}
