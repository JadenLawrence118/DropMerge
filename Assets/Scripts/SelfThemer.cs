using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelfThemer : MonoBehaviour
{
    void Awake()
    {
        if (GameObject.Find("ThemeController") != null)
        {
            ThemeController themeController = GameObject.Find("ThemeController").GetComponent<ThemeController>();
            ObjectTheme gObject = FindObjectOfType<ObjectTheme>();


            if (PlayerPrefs.GetInt("theme", -1) >= 0)
            {
                switch (gObject.themeID)
                {
                    case 1:
                        gObject.UpdateColour(themeController.colour1[PlayerPrefs.GetInt("theme", -1)]);
                        break;
                    case 2:
                        gObject.UpdateColour(themeController.colour2[PlayerPrefs.GetInt("theme", -1)]);
                        break;
                    case 3:
                        gObject.UpdateColour(themeController.colour3[PlayerPrefs.GetInt("theme", -1)]);
                        break;
                    default:
                        gObject.UpdateColour();
                        break;
                }
            }
        }
    }
}
