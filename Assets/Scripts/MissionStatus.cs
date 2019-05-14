using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MissionStatus : MonoBehaviour
{
    public int counter = 0;
    public Text statusText;
    public PlayerHealth playerHealth;
    public string CurrentMissionName;
    public string NextMissionScreenName;
    public Text debugText;
    public int effects;
    public int projectiles;
    public float scores;
    public Text scoreText;

    private bool showDebug = false;

    void Start()
    {
        debugText.enabled = false;
        playerHealth = gameObject.GetComponent<PlayerHealth>();
        Count();
    }

    void FixedUpdate()
    {
        Count();
        if (counter == 0)
        {
            statusText.enabled = true;
            statusText.color = Color.green;
            statusText.text = "Mission accomplished. Press Enter for next mission.";
            if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
            {
                SceneManager.LoadScene(NextMissionScreenName);
            }
        }
        if (playerHealth.CurrentHealth < 0)
        {
            statusText.text = "Mission failed. Press enter to restart mission.";
            statusText.color = Color.red;
            statusText.enabled = true;
            if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter)){
                SceneManager.LoadScene(CurrentMissionName);
            }
        }
        if (Input.GetKey(KeyCode.P))
        {
            showDebug = true;
            debugText.enabled = true;
        }
        if (showDebug)
        {
            debugText.text = "Total enemy object: " + counter + "\nTotal effects: " + effects +"\nTotal projectiles: " + projectiles;
        }
        scores -= Time.deltaTime;
        scoreText.text = scores+"";
    }

    void Count()
    {
        var tmp = GameObject.FindObjectsOfType<GameObject>();
        counter = 0;
        for (int i = 0; i < tmp.Length; i++)
        {
            if (tmp[i].layer == 8 || tmp[i].layer == 9)
            {
                counter++;
            }
        }
    }
}
