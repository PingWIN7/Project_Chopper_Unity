using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    public Text hpText;
    public Image HpBar;
    public Text statusText;

    void Start()
    {
        CurrentHealth = StartingHealth;
        HpBar.transform.localScale = new Vector3(HpBar.transform.localScale.x, 1 - (CurrentHealth / MaxHealth), HpBar.transform.localScale.z);
        statusText.enabled = false;
    }

    public override void Update()
    {
        hpText.text = CurrentHealth+"";
        base.Update();
    }

    public override void Heal(int amount)
    {
        if (CurrentHealth + amount < MaxHealth)
        {
            CurrentHealth += amount;
        }
        else
        {
            CurrentHealth = MaxHealth;
        }
        HpBar.transform.localScale = new Vector3(HpBar.transform.localScale.x, 1 - (CurrentHealth / MaxHealth), HpBar.transform.localScale.z);
    }

    public override void GetHit(float damage)
    {
        CurrentHealth -= damage;
        HpBar.transform.localScale = new Vector3(HpBar.transform.localScale.x, 1 - (CurrentHealth / MaxHealth), HpBar.transform.localScale.z);
        /*if (CurrentHealth <= 0)
        {
            statusText.text = "Mission failed";
            statusText.color = Color.red;
            statusText.enabled = true;
            //Destroy(gameObject);
        }*/
        timer = 0;
    }
}
