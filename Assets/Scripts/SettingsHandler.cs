using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsHandler : MonoBehaviour
{
    public GameObject confirmWindow;
    public GameObject OKWindow;

    private void Awake()
    {
        confirmWindow.SetActive(false);
        OKWindow.SetActive(false);
    }
}
