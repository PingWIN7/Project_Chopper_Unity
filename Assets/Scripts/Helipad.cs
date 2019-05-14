using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helipad : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void OnTriggerStay2D(Collider2D other)
    {
        var tmp = player.GetComponent<PlayerHealth>();
        tmp.Heal(1);
    }
}
