using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public GameObject weapon;
    public GameObject projectile;
    //public Transform target;
    public float weaponTimer = 1;
    //public Transform target;
    private float currentTimer = 0;
    public bool weaponEnabled = true;

    void Start()
    {
        //target = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        if (weaponEnabled)
        {
            currentTimer += Time.deltaTime;
        }
        //Look for a target

        //Check if we can fire
        if (weaponTimer < currentTimer)
        {
            //fire
            fire();
            //currentTimer = 0;
        }
    }

    public void fire()
    {
        if (currentTimer > weaponTimer)
        {
            /*var sr = GetComponent<SpriteRenderer>();
            var sprite = sr.sprite;*/

            Instantiate(projectile, transform.position, GetComponent<Transform>().rotation);


            //Instantiate(projectile, new Vector3(transform.position.x,transform.position.y+sprite.bounds.size.y/2,transform.position.z), GetComponent<Transform>().rotation);
            currentTimer = 0;
        }
    }
}
