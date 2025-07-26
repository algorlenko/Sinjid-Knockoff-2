using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public TextMeshProUGUI manaAmountText;
    public Image manaBarImage;
    public CombatUnit displayedUnit;
    // Start is called before the first frame update
    void Start()
    {
        updateCurrentMana();
    }

    public void updateCurrentMana()
    {
        manaAmountText.text = displayedUnit.CurrentMana + " / " + displayedUnit.totalmana;
        manaBarImage.transform.localScale = new Vector3(((float)displayedUnit.CurrentMana) / (float)displayedUnit.totalmana, 1, 1);
    }


}