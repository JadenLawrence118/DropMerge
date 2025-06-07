using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
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

    IEnumerator FadeAndSwitch(int newScene, GameObject whitePanel)
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<FadeOutHandler>().FadeOut();
        yield return new WaitForSeconds((float)whitePanel.GetComponent<PlayableDirector>().playableAsset.duration);
        SceneManager.LoadScene(newScene);
    }
}
