using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploding : MonoBehaviour
{
    public float explosiveRange = 25;
    public float explosiveTime = 0.5f;
    public float damage = 10;
    private float currentTime = 0;
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > explosiveTime)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var hp = other.GetComponent<Health>();
        if (hp != null)
        {
            hp.GetHit(damage);
        }
    }


}
