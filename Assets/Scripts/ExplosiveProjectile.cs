using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveProjectile : Projectile
{
    public GameObject explosion;
    public GameObject traveleffect;
    public float effectSpawnTime = 0.1f;
    private float currentEffectTime;
    private Health health;

    /*void Start()
    {
        health = GetComponent<Health>();
    }*/

    protected override void FixedUpdate()
    {
        currentEffectTime += Time.deltaTime;
        if (currentEffectTime>effectSpawnTime)
        {
            Instantiate(traveleffect, transform.position, GetComponent<Transform>().rotation);
            currentEffectTime = 0;
        }
        base.FixedUpdate();
    }

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
            var tmp = transform.position;
            tmp = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
            Instantiate(explosion, transform.position, GetComponent<Transform>().rotation);
            Destroy(gameObject);
        }
    }
}
