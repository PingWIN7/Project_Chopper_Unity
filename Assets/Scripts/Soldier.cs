using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    public Transform player;
    //public GameObject Projectile;
    public WeaponScriptState weaponScript;
    public float speed;
    public float range = 15;
    private float breakbetweenFire = 0.1f;
    private float fireAmount = 3;
    private float timer = 0;
    private int currentShotNumber = 0;
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

            if (weaponScript.ready)
            {
                timer += Time.deltaTime;
                rigid.velocity = Vector2.zero;

                if (timer > breakbetweenFire)
                {
                    weaponScript.fireWithoutRestart();
                    currentShotNumber++;
                    timer = 0;
                }
                if (currentShotNumber == fireAmount)
                {
                    weaponScript.restartTimer();
                    timer = 0;
                    currentShotNumber = 0;
                }
            }
            else
            {
                float z = Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;

                transform.eulerAngles = new Vector3(0, 0, z);

                rigid.AddForce(gameObject.transform.up * speed);
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
