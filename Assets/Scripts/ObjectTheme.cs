using System.Collections;
using System.Collections.Generic;
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
        else if (GetComponent<Text>() != null)
        {
            defaultColour = GetComponent<Text>().color;
        }
        else if (GetComponent<Renderer>() != null)
        {
            defaultColour = GetComponent<Renderer>().material.color;
        }
    }

    public void UpdateColour(Color newColour)
    {
        if (GetComponent<Image>() != null)
        {
            GetComponent<Image>().color = newColour;

        }
        else if (GetComponent<Text>() != null)
        {
            GetComponent<Text>().color = newColour;
        }
        else if (GetComponent<Renderer>() != null)
        {
            GetComponent<Renderer>().material.color = newColour;
        }
    }

    public void UpdateColour()
    {
        if (GetComponent<Image>() != null)
        {
            GetComponent<Image>().color = defaultColour;
        }
        else if (GetComponent<Text>() != null)
        {
            GetComponent<Text>().color = defaultColour;
        }
        else if (GetComponent<Renderer>() != null)
        {
            GetComponent<Renderer>().material.color = defaultColour;
        }
    }
}
