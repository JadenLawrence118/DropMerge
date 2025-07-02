using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeController : MonoBehaviour
{
    private static ThemeController self;

    [SerializeField] private Color defaultBackground;

    public Color[] backgroundColour;
    public Color[] colour1;
    public Color[] colour2;
    public Color[] colour3;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (self == null)
        {
            self = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    public void UpdateTheme(int themeIndex)
    {
        if (themeIndex >= 0)
        {
            Camera.main.backgroundColor = backgroundColour[themeIndex];

            for (int i = 0; i < FindObjectsOfType<ObjectTheme>().Length; i++)
            {
                ObjectTheme gObject = FindObjectsOfType<ObjectTheme>()[i];

                switch(gObject.themeID)
                {
                    case 1:
                        gObject.UpdateColour(colour1[themeIndex]);
                        break;
                    case 2:
                        gObject.UpdateColour(colour2[themeIndex]);
                        break;
                    case 3:
                        gObject.UpdateColour(colour3[themeIndex]);
                        break;
                    default:
                        gObject.UpdateColour();
                        break;
                }
            }
        }
        else
        {
            Camera.main.backgroundColor = defaultBackground;
            for (int i = 0; i < FindObjectsOfType<ObjectTheme>().Length; i++)
            {
                ObjectTheme gObject = FindObjectsOfType<ObjectTheme>()[i];
                gObject.UpdateColour();
            }
        }
    }
}
