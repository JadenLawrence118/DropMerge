using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settingsMenu;

    private ThemeController themeController;
    private AudioController audioController;

    private void Awake()
    {
        themeController = GameObject.Find("ThemeController").GetComponent<ThemeController>();
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>();
    }
    public void Play()
    {
        if (GameObject.FindGameObjectWithTag("GameController").GetComponent<FadeOutHandler>() != null)
        {
            StartCoroutine(FadeAndSwitch(2, GameObject.FindGameObjectWithTag("GameController").GetComponent<FadeOutHandler>().fadeToWhite));
        }
        else
        {
            SceneManager.LoadScene(2);
        }
        Time.timeScale = 1.0f;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = false;
        audioController.GamePause();
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = true;
        audioController.GameResume();
    }

    public void Restart()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().restartWindow.SetActive(true);
    }

    public void NoRestart()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().restartWindow.SetActive(false);
    }

    public void EndRound()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().homeWindow.SetActive(true);
    }

    public void NoHome()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().homeWindow.SetActive(false);
    }

    public void Back()
    {
        if (GameObject.FindGameObjectWithTag("GameController").GetComponent<FadeOutHandler>() != null)
        {
            StartCoroutine(FadeAndSwitch(SceneManager.GetActiveScene().buildIndex - 1, GameObject.FindGameObjectWithTag("GameController").GetComponent<FadeOutHandler>().fadeToWhite));
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void Home()
    {
        Time.timeScale = 1.0f;

        if (GameObject.FindGameObjectWithTag("GameController").GetComponent<FadeOutHandler>() != null)
        {
            StartCoroutine(FadeAndSwitch(1, GameObject.FindGameObjectWithTag("GameController").GetComponent<FadeOutHandler>().fadeToWhite));
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    public void OpenInstr()
    {
        StartCoroutine(FadeAndSwitch(3, GameObject.FindGameObjectWithTag("GameController").GetComponent<FadeOutHandler>().fadeToWhite));
    }

    public void OpenSettings()
    {
        StartCoroutine(FadeAndSwitch(4, GameObject.FindGameObjectWithTag("GameController").GetComponent<FadeOutHandler>().fadeToWhite));
    }

    public void OpenAdvancedSettings()
    {
        if (GameObject.FindGameObjectWithTag("GameController").GetComponent<FadeOutHandler>() != null)
        {
            StartCoroutine(FadeAndSwitch(5, GameObject.FindGameObjectWithTag("GameController").GetComponent<FadeOutHandler>().fadeToWhite));
        }
        else
        {
            SceneManager.LoadScene(5);
        }
    }

    public void OpenCosmetics()
    {
        if (GameObject.FindGameObjectWithTag("GameController").GetComponent<FadeOutHandler>() != null)
        {
            StartCoroutine(FadeAndSwitch(6, GameObject.FindGameObjectWithTag("GameController").GetComponent<FadeOutHandler>().fadeToWhite));
        }
        else
        {
            SceneManager.LoadScene(6);
        }
    }

    public void OpenCredits()
    {
        if (GameObject.FindGameObjectWithTag("GameController").GetComponent<FadeOutHandler>() != null)
        {
            StartCoroutine(FadeAndSwitch(7, GameObject.FindGameObjectWithTag("GameController").GetComponent<FadeOutHandler>().fadeToWhite));
        }
        else
        {
            SceneManager.LoadScene(7);
        }
    }

    public void PauseSettings()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void SettingsBack()
    {
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void instrForward()
    {
        InstrHandler controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<InstrHandler>();

        if (controller.InstructionCount < controller.Instructions.Length - 1)
        {
            controller.InstructionCount++;
        }
        else
        {
            controller.InstructionCount = 0;
        }
        controller.UpdateInstr();
    }

    public void instrBack()
    {
        InstrHandler controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<InstrHandler>();

        if (controller.InstructionCount > 0)
        {
            controller.InstructionCount--;
        }
        else
        {
            controller.InstructionCount = controller.Instructions.Length - 1;
        }
        controller.UpdateInstr();
    }

    public void jarsForward()
    {
        CosmeticsHandler controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<CosmeticsHandler>();

        if (controller.JarCount < controller.Jars.Length - 1)
        {
            controller.JarCount++;
        }
        else
        {
            controller.JarCount = 0;
        }
        controller.UpdateJar();
    }

    public void jarsBack()
    {
        CosmeticsHandler controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<CosmeticsHandler>();

        if (controller.JarCount > 0)
        {
            controller.JarCount--;
        }
        else
        {
            controller.JarCount = controller.Jars.Length - 1;
        }
        controller.UpdateJar();
    }

    public void themeForward()
    {
        CosmeticsHandler controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<CosmeticsHandler>();

        if (controller.ThemeCount < controller.Themes.Length - 2)
        {
            controller.ThemeCount++;
        }
        else
        {
            controller.ThemeCount = -1;
        }
        controller.UpdateTheme();
        controller.EnableAll();
        themeController.UpdateTheme(controller.ThemeCount);
        controller.DisableAll();
    }

    public void themeBack()
    {
        CosmeticsHandler controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<CosmeticsHandler>();

        if (controller.ThemeCount > -1)
        {
            controller.ThemeCount--;
        }
        else
        {
            controller.ThemeCount = controller.Themes.Length - 2;
        }
        controller.UpdateTheme();
        controller.EnableAll();
        themeController.UpdateTheme(controller.ThemeCount);
        controller.DisableAll();
    }

    public void purchaseEnable()
    {
        CosmeticsHandler controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<CosmeticsHandler>();

        if (GetComponent<Purchasable>().jar)
        {
            switch (controller.JarCount)
            {
                case 0:
                    PlayerPrefs.SetInt("JarNo", 0);
                    gameObject.SetActive(false);
                    break;
                case 1:
                    if (PlayerPrefs.GetInt("Jar1", 0) < 1)
                    {
                        if (PlayerPrefs.GetInt("points", 0) >= controller.jar1Cost)
                        {
                            controller.confirmPanel.SetActive(true);
                            controller.confirmButton.GetComponent<Button>().onClick.RemoveAllListeners();
                            controller.confirmButton.GetComponent<Button>().onClick.AddListener(() => jarsConfirm(1, controller.jar1Cost));
                        }
                    }
                    else
                    {
                        PlayerPrefs.SetInt("JarNo", 1);
                        gameObject.SetActive(false);
                    }
                    break;
                case 2:
                    if (PlayerPrefs.GetInt("Jar2", 0) < 1)
                    {
                        if (PlayerPrefs.GetInt("points", 0) >= controller.jar2Cost)
                        {
                            controller.confirmPanel.SetActive(true);
                            controller.confirmButton.GetComponent<Button>().onClick.RemoveAllListeners();
                            controller.confirmButton.GetComponent<Button>().onClick.AddListener(() => jarsConfirm(2, controller.jar2Cost));
                        }
                    }
                    else
                    {
                        PlayerPrefs.SetInt("JarNo", 2);
                        gameObject.SetActive(false);
                    }
                    break;
                default:
                    PlayerPrefs.SetInt("JarNo", 0);
                    gameObject.SetActive(false);
                    break;
            }
        }
        else if (GetComponent<Purchasable>().theme)
        {
            switch (controller.ThemeCount + 1)
            {
                case 0:
                    PlayerPrefs.SetInt("theme", -1);
                    gameObject.SetActive(false);
                    break;

                case 1:
                    if (PlayerPrefs.GetInt("Theme1", 0) < 1)
                    {
                        if (PlayerPrefs.GetInt("points", 0) >= controller.theme1Cost)
                        {
                            controller.confirmPanel.SetActive(true);
                            controller.confirmButton.GetComponent<Button>().onClick.RemoveAllListeners();
                            controller.confirmButton.GetComponent<Button>().onClick.AddListener(() => themesConfirm(controller.theme1Cost));
                        }
                    }
                    else
                    {
                        PlayerPrefs.SetInt("theme", 0);
                        gameObject.SetActive(false);
                    }
                    break;

                case 2:
                    if (PlayerPrefs.GetInt("Theme2", 0) < 1)
                    {
                        if (PlayerPrefs.GetInt("points", 0) >= controller.theme2Cost)
                        {
                            controller.confirmPanel.SetActive(true);
                            controller.confirmButton.GetComponent<Button>().onClick.RemoveAllListeners();
                            controller.confirmButton.GetComponent<Button>().onClick.AddListener(() => themesConfirm(controller.theme2Cost));
                        }
                    }
                    else
                    {
                        PlayerPrefs.SetInt("theme", 1);
                        gameObject.SetActive(false);
                    }
                    break;

                default:
                    PlayerPrefs.SetInt("theme", -1);
                    gameObject.SetActive(false);
                    break;
            }
        }
    }

    public void jarsConfirm(int jarNo, int price)
    {
        CosmeticsHandler controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<CosmeticsHandler>();
        
        PlayerPrefs.SetInt("Jar" + jarNo.ToString(), 1);
        PlayerPrefs.SetInt("points", PlayerPrefs.GetInt("points", 0) - price);
        controller.pointsText.text = "Available Points: " + PlayerPrefs.GetInt("points", 0).ToString();
        PlayerPrefs.SetInt("JarNo", jarNo);
        controller.confirmPanel.SetActive(false);
        gameObject.SetActive(false);
        controller.jarCostPanel.SetActive(false);
    }

    public void themesConfirm(int price)
    {
        CosmeticsHandler controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<CosmeticsHandler>();

        PlayerPrefs.SetInt("theme", controller.ThemeCount);
        PlayerPrefs.SetInt("points", PlayerPrefs.GetInt("points", 0) - price);
        controller.pointsText.text = "Available Points: " + PlayerPrefs.GetInt("points", 0).ToString();
        PlayerPrefs.SetInt("Theme" + (controller.ThemeCount + 1).ToString(), 1);
        controller.confirmPanel.SetActive(false);
        gameObject.SetActive(false);
        controller.themeCostPanel.SetActive(false);
    }

    public void purchaseReject()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<CosmeticsHandler>().confirmPanel.SetActive(false);
    }

    IEnumerator FadeAndSwitch(int newScene, GameObject whitePanel)
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<FadeOutHandler>().FadeOut();
        yield return new WaitForSeconds((float)whitePanel.GetComponent<PlayableDirector>().playableAsset.duration);
        SceneManager.LoadScene(newScene);
    }
}
