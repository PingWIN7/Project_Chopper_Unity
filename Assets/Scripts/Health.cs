using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float StartingHealth = 100;
    public float MaxHealth = 100;
    public float CurrentHealth;

    private float maxColorTime = 0.125f;
    private float timer;

    private SpriteRenderer spriteRender;


    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = StartingHealth;
        spriteRender = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if (timer < maxColorTime)
        {
            //spriteRender.material.color = Color.yellow;
            spriteRender.color = Color.red;
        }
        else
        {
            spriteRender.color = Color.white;
        }

    }


    public void GetHit(float damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
        timer = 0;
    }
}
