using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CosmeticsHandler : MonoBehaviour
{
    public TextMeshProUGUI pointsText;

    public GameObject[] Jars;
    public int JarCount = 0;

    void Awake()
    {
        pointsText.text = "Available Points: " + PlayerPrefs.GetInt("points", 0).ToString();

        JarCount = PlayerPrefs.GetInt("JarNo", 0);
        UpdateJar();
    }

    public void UpdateJar()
    {
        for (int i = 0; i < Jars.Length; i++)
        {
            Jars[i].SetActive(false);
        }
        Jars[JarCount].SetActive(true);
        PlayerPrefs.SetInt("JarNo", JarCount);
    }
}
