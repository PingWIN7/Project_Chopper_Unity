using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{

    public Transform player;
    public WeaponScript weapon;
    public float range = 10;
    //public float speed;

    void Start()
    {
        var tmp = GameObject.Find("Player");
        player = tmp.transform;
        weapon = GetComponent<WeaponScript>();
    }

    void FixedUpdate()
    {
        float z = Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;

        transform.eulerAngles = new Vector3(0, 0, z);
        var distance = Vector2.Distance(player.transform.position, gameObject.transform.position);
        if (distance < range)
        {
            weapon.weaponEnabled = true;
        }
        else
        {
            weapon.weaponEnabled = false;
        }

        //GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * speed); //Use this line for soldiers
    }

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
