﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 1;
    public float deathTimer = 5;
    public int damage = 5;
    protected float timer;
    MissionStatus mstatus;

    protected Rigidbody2D rigid;

    void Start()
    {
        mstatus = GameObject.FindObjectOfType<MissionStatus>();
        mstatus.projectiles++;
        rigid = GetComponent<Rigidbody2D>();
    }

    protected virtual void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= deathTimer)
        {
            ReachedDeathTime();
        }
        rigid.AddForce(gameObject.transform.up * speed, ForceMode2D.Impulse);

        //transform.Translate(Vector3.forward* Time.deltaTime);
        //GetComponent<Rigidbody2D>().MovePosition(Vector2.up);
    }

    protected virtual void ReachedDeathTime()
    {
        mstatus.projectiles--;
        Destroy(gameObject);
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }


    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Triggered by: " + other.name);
        var hp = other.GetComponent<Health>();
        if (hp != null)
        {
            hp.GetHit(damage);
            Destroy(gameObject);
            mstatus.projectiles--;
        }

    }
}
