using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    public Text hpText;


    void Update()
    {
        hpText.text = CurrentHealth+"";
    }
}
