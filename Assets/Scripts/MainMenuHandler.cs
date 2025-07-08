using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHandler : MonoBehaviour
{
    void Start()
    {
        GameObject.FindGameObjectWithTag("ThemeController").GetComponent<ThemeController>().UpdateTheme(PlayerPrefs.GetInt("theme", -1));
        GameObject.Find("AudioController").GetComponent<AudioController>().MenuStart();
    }
}
