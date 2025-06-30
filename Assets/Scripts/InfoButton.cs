using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoButton : MonoBehaviour
{
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private string info;

    public void DisplayInfo()
    {
        infoPanel.SetActive(true);
        infoText.text = info;
    }

    public void HideInfo()
    {
        infoPanel.SetActive(false);
    }
}
