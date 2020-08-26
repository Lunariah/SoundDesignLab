using UnityEngine;
using System.Collections.Generic;

public class LaunchGame : MonoBehaviour
{
    public void HideUI()
    {
        GameObject menuUI = GameObject.Find("MenuUI");
        menuUI.SetActive(false);
        GameObject fpsController = GameObject.Find("FPSController");
        (fpsController.GetComponent("FirstPersonController") as MonoBehaviour).enabled = true;
    }
}