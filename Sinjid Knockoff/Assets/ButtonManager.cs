using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonManager : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public CombatAbility.AbilitySelected abilityThisButtonCorrespondsTo;
    public static Dictionary<CombatAbility.AbilitySelected, CombatAbility> abilityDictionary;
    public TextMeshProUGUI descriptionField;
    void Awake()
    {
        if (abilityDictionary != null)
        {
            abilityDictionary = null;
        }
    }
    void Start()
    {
        if (abilityDictionary == null)
        {
            abilityDictionary = new Dictionary<CombatAbility.AbilitySelected, CombatAbility>();
            abilityDictionary.Add(CombatAbility.AbilitySelected.HEAL, new HealAbility());
            abilityDictionary.Add(CombatAbility.AbilitySelected.FURIOUSSTRIKE, new FuriousStrikeAbility());
            abilityDictionary.Add(CombatAbility.AbilitySelected.MAGICBLAST, new MagicBlastAbility());
            abilityDictionary.Add(CombatAbility.AbilitySelected.BASICATTACK, new BasicAttackAbility());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void abilityButtonPressed()
    {
        /*switch (abilityThisButtonCorrespondsTo)
        {
            case CombatAbility.AbilitySelected.HEAL:
                HealAbility.abilityUsed(Hero.instance, Hero.instance);
                break;
            case CombatAbility.AbilitySelected.BASICATTACK:
                BasicAttackAbility.abilityUsed(Hero.instance, Hero.instance.currentlyTargetedEnemy);
                break;
            case CombatAbility.AbilitySelected.FURIOUSSTRIKE:
                FuriousStrikeAbility.abilityUsed(Hero.instance, Hero.instance.currentlyTargetedEnemy);
                break;
            case CombatAbility.AbilitySelected.MAGICBLAST:
                MagicBlastAbility.abilityUsed(Hero.instance, Hero.instance.currentlyTargetedEnemy);
                break;
            default:
                break;
        }*/
        abilityDictionary[abilityThisButtonCorrespondsTo].abilityUsed(Hero.instance, Hero.instance.currentlyTargetedEnemy);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
       // Animator myAnimator;
        //if(myAnimator.pla)
        abilityButtonPressed();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        descriptionField.text = "Ability Description: " + abilityDictionary[abilityThisButtonCorrespondsTo].description;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        descriptionField.text = "Ability Description:";
    }
}
