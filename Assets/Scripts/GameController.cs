using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject EndUI;
    [SerializeField] private GameObject PauseUI;
    [SerializeField] private TextMeshProUGUI EndScore;
    [SerializeField] private TextMeshProUGUI HighScore;
    private PlayerController playerController;
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        EndUI.SetActive(false);
        PauseUI.SetActive(false);
    }

    public void EndGame()
    {
        if (playerController.points > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", playerController.points);
        }

        EndScore.text = "Score: " + playerController.points;
        HighScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore");

        playerController.enabled = false;
        EndUI.SetActive(true);
    }
}
