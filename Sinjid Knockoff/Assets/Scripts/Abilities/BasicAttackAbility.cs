using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttackAbility : CombatAbility
{
    public BasicAttackAbility() { manaCost = 0; description = "default basic strike"; }
    // protected static new void preformTheActualAbility(CombatUnit userOfAbility, CombatUnit targetOfAbility) // used to be this way
    protected override void preformTheActualAbility(CombatUnit userOfAbility, CombatUnit targetOfAbility)
    {
        targetOfAbility.CurrentHealth = Math.Max(0, targetOfAbility.CurrentHealth - userOfAbility.damage);
        if (userOfAbility = Hero.instance) // TODO UNHARDCODE THIS!!!!!
        {
            Hero.instance.GetComponent<Animator>().Play("HeroAttack");
        }
    }
}
