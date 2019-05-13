using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveProjectile : Projectile
{
    public GameObject explosion;
    private Health health;

    /*void Start()
    {
        health = GetComponent<Health>();
    }*/

    protected override void ReachedDeathTime()
    {
        Instantiate(explosion, transform.position, GetComponent<Transform>().rotation);
        base.ReachedDeathTime();
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        var hp = other.GetComponent<Health>();
        if (hp != null)
        {
            hp.GetHit(damage);
            Instantiate(explosion, transform.position, GetComponent<Transform>().rotation);
            Destroy(gameObject);
        }
    }
}
