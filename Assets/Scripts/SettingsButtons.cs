using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButtons : MonoBehaviour
{
    private SettingsHandler controller;
    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<SettingsHandler>();
    }

    public void GetConfirmation()
    {
        controller.confirmWindow.SetActive(true);
    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        controller.confirmWindow.SetActive(false);
        controller.OKWindow.SetActive(true);
    }

    public void Reject()
    {
        controller.confirmWindow.SetActive(false);
    }

    public void OK()
    {
        controller.OKWindow.SetActive(false);
    }
}
