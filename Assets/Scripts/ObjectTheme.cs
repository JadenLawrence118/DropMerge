using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class ObjectTheme : MonoBehaviour
{
    public int themeID = 0;
    private Color defaultColour;

    void Awake()
    {
        if (GetComponent<Image>() != null)
        {
            defaultColour = GetComponent<Image>().color;
        }
        else if (GetComponent<TextMeshProUGUI>() != null)
        {
            defaultColour = GetComponent<TextMeshProUGUI>().color;
        }
        else if (GetComponent<SpriteRenderer>() != null)
        {
            defaultColour = GetComponent<SpriteRenderer>().color;
        }
    }

    public void UpdateColour(Color newColour)
    {
        if (GetComponent<Image>() != null)
        {
            GetComponent<Image>().color = newColour;

        }
        else if (GetComponent<TextMeshProUGUI>() != null)
        {
            GetComponent<TextMeshProUGUI>().color = newColour;
        }
        else if (GetComponent<SpriteRenderer>() != null)
        {
            GetComponent<SpriteRenderer>().color = newColour;
        }
    }

    public void UpdateColour()
    {
        if (GetComponent<Image>() != null)
        {
            GetComponent<Image>().color = defaultColour;
        }
        else if (GetComponent<TextMeshProUGUI>() != null)
        {
            GetComponent<TextMeshProUGUI>().color = defaultColour;
        }
        else if (GetComponent<SpriteRenderer>() != null)
        {
            GetComponent<SpriteRenderer>().color = defaultColour;
        }
    }
}
