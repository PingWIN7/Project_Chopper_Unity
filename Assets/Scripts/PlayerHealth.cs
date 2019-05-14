using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    public Text hpText;
    public Image HpBar;


    void Update()
    {
        hpText.text = CurrentHealth+"";
        base.Update();
    }

    void OnGui()
    {
        GUI.Box(new Rect(0, 0, HpBar.mainTexture.height,100), HpBar.mainTexture);
    }
}
