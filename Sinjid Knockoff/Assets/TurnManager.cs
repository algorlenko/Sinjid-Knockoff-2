using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static List<CombatUnit> presentCombatUnits;
    public static CombatUnit currentUnitInControl;
    public void Start()
    {
        presentCombatUnits = new List<CombatUnit>();
        foreach(CombatUnit presentUnit in GameObject.FindObjectsOfType<CombatUnit>())
        {
            presentCombatUnits.Add(presentUnit);
        }
        initializeFight();
    }

    public void initializeFight()
    {
        currentUnitInControl = Hero.instance;
    }

    public static void transferControl(CombatUnit nextUnit)
    {
        currentUnitInControl.isCurrentlyMyTurn = false;
        nextUnit.isCurrentlyMyTurn = true;
        if(nextUnit.GetType() == typeof(Enemy))
        {
            ((Enemy)nextUnit).preformEnemyAIAction(); 
        }
    }
}
