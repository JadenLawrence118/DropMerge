using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SettingsHandler : MonoBehaviour
{
    public GameObject confirmWindow;
    public GameObject OKWindow;
    public TextMeshProUGUI HighScore;

    private void Awake()
    {
        confirmWindow.SetActive(false);
        OKWindow.SetActive(false);
        HighScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
    }
}
