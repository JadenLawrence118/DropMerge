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
}
