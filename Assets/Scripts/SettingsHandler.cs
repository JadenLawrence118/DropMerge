using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SettingsHandler : MonoBehaviour
{
    public GameObject confirmWindow;
    public GameObject OKWindow;
    public TextMeshProUGUI HighScore;
    public UnityEngine.UI.Slider musicSlider;
    public UnityEngine.UI.Slider SFXSlider;

    private void Awake()
    {
        confirmWindow.SetActive(false);
        OKWindow.SetActive(false);
        HighScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        musicSlider.value = PlayerPrefs.GetFloat("musicVol", 1.0f);
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVol", 1.0f);
    }
}
