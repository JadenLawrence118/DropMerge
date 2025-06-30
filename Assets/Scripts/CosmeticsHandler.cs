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

    [SerializeField] private Button enableButton;
    public int jar1Cost = 20000;

    public GameObject costPanel;

    public GameObject confirmPanel;
    public GameObject confirmButton;

    void Awake()
    {
        confirmPanel.SetActive(false);

        pointsText.text = "Available Points: " + PlayerPrefs.GetInt("points", 0).ToString();

        JarCount = PlayerPrefs.GetInt("JarNo", 0);
        UpdateJar();
    }

    public void UpdateJar()
    {
        costPanel.SetActive(false);
        for (int i = 0; i < Jars.Length; i++)
        {
            Jars[i].SetActive(false);
        }
        Jars[JarCount].SetActive(true);

        if (PlayerPrefs.GetInt("JarNo", 0) == JarCount)
        {
            enableButton.gameObject.SetActive(false);
        }
        else
        {
            enableButton.gameObject.SetActive(true);
            switch (JarCount)
            {
                case 0:
                    enableButton.GetComponentInChildren<TextMeshProUGUI>().text = "Enable";
                    break;
                case 1:
                    if (PlayerPrefs.GetInt("Jar1", 0) < 1)
                    {
                        enableButton.GetComponentInChildren<TextMeshProUGUI>().text = "Purchase";
                        costPanel.SetActive(true);
                        costPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Cost:\n" + jar1Cost.ToString();
                    }
                    else
                    {
                        enableButton.GetComponentInChildren<TextMeshProUGUI>().text = "Enable";
                    }
                    break;
                default:
                    enableButton.GetComponentInChildren<TextMeshProUGUI>().text = "Enable";
                    break;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.U))
        {
            PlayerPrefs.SetInt("points", PlayerPrefs.GetInt("points", 0) + 1000);
            print(PlayerPrefs.GetInt("points", 0));
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            PlayerPrefs.SetInt("points", PlayerPrefs.GetInt("points", 0) - 1000);
            print(PlayerPrefs.GetInt("points", 0));
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            PlayerPrefs.SetInt("Jar1", 0);
        }
    }
}
