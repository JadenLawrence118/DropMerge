using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settingsMenu;
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
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = true;
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
                            controller.confirmButton.GetComponent<Button>().onClick.AddListener(jarsConfirm);
                        }
                    }
                    else
                    {
                        PlayerPrefs.SetInt("JarNo", 1);
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

        }
    }

    public void jarsConfirm()
    {
        CosmeticsHandler controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<CosmeticsHandler>();
        
        PlayerPrefs.SetInt("Jar1", 1);
        PlayerPrefs.SetInt("points", PlayerPrefs.GetInt("points", 0) - controller.jar1Cost);
        controller.pointsText.text = "Available Points: " + PlayerPrefs.GetInt("points", 0).ToString();
        PlayerPrefs.SetInt("JarNo", 1);
        controller.confirmPanel.SetActive(false);
        gameObject.SetActive(false);
        controller.costPanel.SetActive(false);
    }

    public void jarsReject()
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
