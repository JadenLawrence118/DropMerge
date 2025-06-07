using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public void Play()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(2);
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
        SceneManager.LoadScene(1);
    }

    public void OpenInstr()
    {
        SceneManager.LoadScene(3);
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene(4);
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
}
