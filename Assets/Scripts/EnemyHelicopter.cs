using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHelicopter : MonoBehaviour
{
    private Transform player;
    //public GameObject Projectile;
    public WeaponScriptState weaponScript;
    public float range = 25;
    public float speed;
    private Rigidbody2D rigid;


    void Start()
    {
        weaponScript = GetComponent<WeaponScriptState>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        var distance = Vector2.Distance(player.transform.position, gameObject.transform.position);
        if (distance < range)
        {
            float z = Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;

            transform.eulerAngles = new Vector3(0, 0, z);

            GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * speed);

            if (weaponScript.ready)
            {
                weaponScript.fire();
            }
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
