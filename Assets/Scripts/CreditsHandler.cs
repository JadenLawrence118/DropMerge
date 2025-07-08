using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsHandler : MonoBehaviour
{
    void Start()
    {
        GameObject.FindGameObjectWithTag("ThemeController").GetComponent<ThemeController>().UpdateTheme(PlayerPrefs.GetInt("theme", -1));
    }
}
