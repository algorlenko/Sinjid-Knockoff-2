using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class CombatAbility
{
    CombatUnit target;
    public CombatUnit userOfTheAbility; // we may be needing to delete this variable entirely.
    [SerializeField] public int manaCost;
    public string description;

    public virtual bool checkRequirementsToCast(CombatUnit userOfAbility) // everything used to be static.
    {
        if(userOfAbility.CurrentMana >= manaCost)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool abilityUsed(CombatUnit userOfAbility, CombatUnit targetOfAbility)
    {
        if (checkRequirementsToCast(userOfAbility))
        {
            userOfAbility.CurrentMana -= manaCost;
            preformTheActualAbility(userOfAbility, targetOfAbility); // and play the animation
            TurnManager.transferControl(targetOfAbility);
            return true;
        }
        else
        {
            return false;
        }
    }
    protected virtual void preformTheActualAbility(CombatUnit userOfAbility, CombatUnit targetOfAbility)
    {

    }
    public enum AbilitySelected
    {
        HEAL,
        BASICATTACK,
        MAGICBLAST,
        FURIOUSSTRIKE
    }
}
public class FuriousStrikeAbility : CombatAbility
{
    public FuriousStrikeAbility() { manaCost = 10; description = "deals 1.5x strike damage"; }
    protected override void preformTheActualAbility(CombatUnit userOfAbility, CombatUnit targetOfAbility)
    {
        targetOfAbility.CurrentHealth = Math.Max(0, targetOfAbility.CurrentHealth - (int)(userOfAbility.damage * 1.5f));
    }
}
public class MagicBlastAbility : CombatAbility
{
    public MagicBlastAbility() { manaCost = 40; description = "deals 2x spell power in damage to one target."; }
    protected override void preformTheActualAbility(CombatUnit userOfAbility, CombatUnit targetOfAbility)
    {
        targetOfAbility.CurrentHealth = Math.Max(0, targetOfAbility.CurrentHealth - (userOfAbility.spellPower * 2));
    }
}

    public class HealAbility : CombatAbility
{
    public HealAbility() { manaCost = 20; description = "heals you for 1x of spell power."; }
    protected override void preformTheActualAbility(CombatUnit userOfAbility, CombatUnit targetOfAbility)
    {
        userOfAbility.CurrentHealth = Math.Min(userOfAbility.totalhealth, userOfAbility.CurrentHealth + userOfAbility.spellPower); 
    }
}
