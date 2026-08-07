using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUnit : MonoBehaviour
{
    public int totalhealth = 100;
    public int damage = 20;
    public int totalmana = 100;
    private int currentHealth;
    private int currentMana;
    public int spellPower;
    public string nameOfUnit;
    public HealthBar myHealthBar;
    public ManaBar myManaBar;
    public bool isCurrentlyMyTurn = false; // NEED TO FOLLOW UP ON THIS ASAP!!!!!
    public int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; myHealthBar.updateCurrentHealth(); }
    }

    public int CurrentMana
    {
        get { return currentMana; }
        set { currentMana = value; if(myManaBar != null) myManaBar.updateCurrentMana(); }
    }


    // Start is called before the first frame update
    public void Awake()
    {
        battleStart();
    }

    void battleStart()
    {
        CurrentHealth = totalhealth;
        CurrentMana = totalmana;
    }

    bool useAbility()//CombatAbility abilityToCast)
    {
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
