using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 1;
    public float deathTimer = 5;
    public int damage = 5;
    protected float timer;

    protected Rigidbody2D rigid;

    void Start()
    {
       rigid= GetComponent<Rigidbody2D>();
    }

    protected void FixedUpdate()
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
        Destroy(gameObject);
    }


    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Triggered by: " + other.name);
        var hp = other.GetComponent<Health>();
        if (hp != null)
        {
            hp.GetHit(damage);
            Destroy(gameObject);
        }

    }
}
