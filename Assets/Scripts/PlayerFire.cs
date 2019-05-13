using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    //public Rigidbody2D bullet;

    PlayerWeaponScript ChildGameObject1;
    PlayerWeaponScript ChildGameObject2;
    PlayerWeaponScript ChildGameObject3;

    void Start()
    {
        ChildGameObject1 = transform.parent.transform.GetChild(0).GetComponent<PlayerWeaponScript>();
        ChildGameObject2 = transform.parent.transform.GetChild(1).GetComponent<PlayerWeaponScript>();
        ChildGameObject3 = transform.parent.transform.GetChild(2).GetComponent<PlayerWeaponScript>();
    }


    void FixedUpdate()
    {
        float input = Input.GetAxis("Fire1");
        if (input != 0)
        {
            ChildGameObject1.fire();
            ChildGameObject2.fire();
            ChildGameObject3.fire();
            //Instantiate(bullet, transform.position, GetComponent<Transform>().rotation); //works fine
        }

    }
}
