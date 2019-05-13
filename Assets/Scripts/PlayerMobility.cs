using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobility : MonoBehaviour
{

    public float speed;
    public float turnSpeed = 40;
    public float health = 2000;
    public float fuel = 1000000;
    private float currentValue = 0;

    void FixedUpdate()
    {
        float input = Input.GetAxis("Rotation");

        //I need to find a way without needing to run 2 if statement here
        if (input > 0.05f)
        {
            input = 0.05f;
        } else if (input < -0.05f)
        {
            input = -0.05f;
        }
        
        currentValue += input;
        
        transform.eulerAngles = new Vector3(0, 0, currentValue * turnSpeed);

        GetComponent<Rigidbody2D>().angularVelocity = 0;

        input = Input.GetAxis("Vertical");
        GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * speed * input);

        input = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().AddForce(gameObject.transform.right * speed * input);
    }
    
}
