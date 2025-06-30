using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsHandler : MonoBehaviour
{
    [SerializeField] private GameObject infoPanel;
    void Awake()
    {
        infoPanel.SetActive(false);
    }
}
