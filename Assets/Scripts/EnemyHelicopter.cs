using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHelicopter : MonoBehaviour
{
    public Transform player;
    //public GameObject Projectile;
    public WeaponScriptState weaponScript;
    public float speed;
    

    void Start()
    {
        weaponScript = GetComponent<WeaponScriptState>();
        player= GameObject.Find("Player").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        float z = Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;

        transform.eulerAngles = new Vector3(0, 0, z);        

        GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * speed);

        if (weaponScript.ready)
        {
            weaponScript.fire();
        }

    }

    /*// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

}
