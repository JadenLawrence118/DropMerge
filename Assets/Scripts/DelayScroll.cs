using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DelayScroll : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI delayText;
    void Awake()
    {
        GetComponent<Scrollbar>().value = PlayerPrefs.GetFloat("dropDelay", 0.5f);
        delayText.text = PlayerPrefs.GetFloat("dropDelay", 0.5f) + "s";
    }

    public void ChangeDelay()
    {
        PlayerPrefs.SetFloat("dropDelay", GetComponent<Scrollbar>().value);
        delayText.text = PlayerPrefs.GetFloat("dropDelay", 0.5f) + "s";
    }
}
