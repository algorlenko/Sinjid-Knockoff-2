using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public TextMeshProUGUI healthAmountText;
    public Image healthBarImage;
    public TextMeshProUGUI nameText;
    public CombatUnit displayedUnit;
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = displayedUnit.nameOfUnit + " :";
        updateCurrentHealth();
    }

    public void updateCurrentHealth()
    {
        healthAmountText.text = displayedUnit.CurrentHealth + " / " + displayedUnit.totalhealth;
        healthBarImage.transform.localScale = new Vector3(((float) displayedUnit.CurrentHealth) / (float) displayedUnit.totalhealth, 1, 1) ;
    }

    
}
