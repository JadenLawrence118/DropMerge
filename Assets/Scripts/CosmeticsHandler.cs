using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CosmeticsHandler : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    void Awake()
    {
        pointsText.text = "Available Points: " + PlayerPrefs.GetInt("points", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
