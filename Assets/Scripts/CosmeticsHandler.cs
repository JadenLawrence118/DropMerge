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

    public GameObject[] Themes;
    public int ThemeCount = -1;

    [SerializeField] private Button jarEnableButton;
    [SerializeField] private Button themeEnableButton;

    public GameObject jarCostPanel;
    public GameObject themeCostPanel;


    public int jar1Cost = 20000;

    public int theme1Cost = 10000;
    public int theme2Cost = 10000;

    public GameObject confirmPanel;
    public GameObject confirmButton;

    void Awake()
    {
        pointsText.text = "Available Points: " + PlayerPrefs.GetInt("points", 0).ToString();

        JarCount = PlayerPrefs.GetInt("JarNo", 0);
        ThemeCount = PlayerPrefs.GetInt("theme", -1);
    }

    private void Start()
    {
        GameObject.FindGameObjectWithTag("ThemeController").GetComponent<ThemeController>().UpdateTheme(PlayerPrefs.GetInt("theme", -1));
        confirmPanel.SetActive(false);
        UpdateJar();
        UpdateTheme();
    }

    public void UpdateJar()
    {
        jarCostPanel.SetActive(false);
        for (int i = 0; i < Jars.Length; i++)
        {
            Jars[i].SetActive(false);
        }
        Jars[JarCount].SetActive(true);

        if (PlayerPrefs.GetInt("JarNo", 0) == JarCount)
        {
            jarEnableButton.gameObject.SetActive(false);
        }
        else
        {
            jarEnableButton.gameObject.SetActive(true);
            switch (JarCount)
            {
                case 0:
                    jarEnableButton.GetComponentInChildren<TextMeshProUGUI>().text = "Enable";
                    break;
                case 1:
                    if (PlayerPrefs.GetInt("Jar1", 0) < 1)
                    {
                        jarEnableButton.GetComponentInChildren<TextMeshProUGUI>().text = "Purchase";
                        jarCostPanel.SetActive(true);
                        jarCostPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Cost:\n" + jar1Cost.ToString();
                    }
                    else
                    {
                        jarEnableButton.GetComponentInChildren<TextMeshProUGUI>().text = "Enable";
                    }
                    break;
                default:
                    jarEnableButton.GetComponentInChildren<TextMeshProUGUI>().text = "Enable";
                    break;
            }
        }
    }

    public void UpdateTheme()
    {
        themeCostPanel.SetActive(false);
        for (int i = 0; i < Themes.Length; i++)
        {
            Themes[i].SetActive(false);
        }
        Themes[ThemeCount + 1].SetActive(true);

        if (PlayerPrefs.GetInt("theme", 0) == ThemeCount)
        {
            themeEnableButton.gameObject.SetActive(false);
        }
        else
        {
            themeEnableButton.gameObject.SetActive(true);
            switch (ThemeCount + 1)
            {
                case 0:
                    themeEnableButton.GetComponentInChildren<TextMeshProUGUI>().text = "Enable";
                    break;

                case 1:
                    if (PlayerPrefs.GetInt("Theme1", 0) < 1)
                    {
                        themeEnableButton.GetComponentInChildren<TextMeshProUGUI>().text = "Purchase";
                        themeCostPanel.SetActive(true);
                        themeCostPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Cost:\n" + theme1Cost.ToString();
                    }
                    else
                    {
                        themeEnableButton.GetComponentInChildren<TextMeshProUGUI>().text = "Enable";
                    }
                    break;

                case 2:
                    if (PlayerPrefs.GetInt("Theme2", 0) < 1)
                    {
                        themeEnableButton.GetComponentInChildren<TextMeshProUGUI>().text = "Purchase";
                        themeCostPanel.SetActive(true);
                        themeCostPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Cost:\n" + theme2Cost.ToString();
                    }
                    else
                    {
                        themeEnableButton.GetComponentInChildren<TextMeshProUGUI>().text = "Enable";
                    }
                    break;

                default:
                    themeEnableButton.GetComponentInChildren<TextMeshProUGUI>().text = "Enable";
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
            PlayerPrefs.SetInt("Theme1", 0);
            PlayerPrefs.SetInt("Theme2", 0);
        }
    }
}
