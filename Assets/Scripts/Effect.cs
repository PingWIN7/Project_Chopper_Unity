using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    MissionStatus mstatus;
    void Start()
    {
        mstatus = GameObject.FindObjectOfType<MissionStatus>();
        mstatus.effects++;
    }

    void EndAnimation()
    {
        mstatus.effects--;
        Destroy(gameObject);
    }
}
