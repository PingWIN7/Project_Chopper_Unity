using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MissionStart : MonoBehaviour
{
    public string MissionName;
    public Button button;


    public void OnClick()
    {
        SceneManager.LoadScene(MissionName);
    }
}
