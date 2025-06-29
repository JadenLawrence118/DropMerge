using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public void ChangeMusic()
    {
        PlayerPrefs.SetFloat("musicVol", GetComponent<Slider>().value);

        for (int i = 0; i < FindObjectsOfType<AudioHandler>().Length; i++)
        {
            FindObjectsOfType<AudioHandler>()[i].UpdateAudio();
        }
    }

    public void ChangeSFX()
    {
        PlayerPrefs.SetFloat("SFXVol", GetComponent<Slider>().value);

        for (int i = 0; i < FindObjectsOfType<AudioHandler>().Length; i++)
        {
            FindObjectsOfType<AudioHandler>()[i].UpdateAudio();
        }
    }

    public void AddDroppable()
    {
        if (PlayerPrefs.GetInt("maxDropCandy", 3) < 5)
        {
            PlayerPrefs.SetInt("maxDropCandy", PlayerPrefs.GetInt("maxDropCandy") + 1);
            GameObject.Find("Panel").GetComponent<DroppableCandies>().ManualUpdate();
        }
    }
    public void SubDroppable()
    {
        if (PlayerPrefs.GetInt("maxDropCandy", 3) > 1)
        {
            PlayerPrefs.SetInt("maxDropCandy", PlayerPrefs.GetInt("maxDropCandy") - 1);
            GameObject.Find("Panel").GetComponent<DroppableCandies>().ManualUpdate();
        }
    }
}
