using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobility : MonoBehaviour
{

    public float speed;
    public float turnSpeed = 1.75f / 60.0f;
    public float health = 2000;
    public float fuel = 1000000;
    private float currentValue = 0;

    void FixedUpdate()
    {
        //var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Quaternion rot = Quaternion.LookRotation(transform.position-mousePosition,Vector3.forward);

        float input = Input.GetAxis("Rotation");

        if (input > 0.05f)
        {
            input = 0.05f;
        } else if (input < -0.05f)
        {
            input = -0.05f;
        }
        
        currentValue += input;

        //Quaternion rot = Quaternion.LookRotation(transform.position*input, Vector3.forward);

        //Quaternion rot = Quaternion.Euler(input, input, input);

        //transform.rotation = rot;
        //transform.Rotate((currentValue * turnSpeed)%180 - 90, 0, 0);
        //transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        transform.eulerAngles = new Vector3(0, 0, currentValue * turnSpeed);

        GetComponent<Rigidbody2D>().angularVelocity = 0;

        input = Input.GetAxis("Vertical");
        GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * speed * input);

        input = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().AddForce(gameObject.transform.right * speed * input);
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
