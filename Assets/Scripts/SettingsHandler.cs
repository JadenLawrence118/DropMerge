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
        HighScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        musicSlider.value = PlayerPrefs.GetFloat("musicVol", 1.0f);
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVol", 1.0f);
    }

    private void Start()
    {
        GameObject.FindGameObjectWithTag("ThemeController").GetComponent<ThemeController>().UpdateTheme(PlayerPrefs.GetInt("theme", -1));
        confirmWindow.SetActive(false);
        OKWindow.SetActive(false);
    }
}
