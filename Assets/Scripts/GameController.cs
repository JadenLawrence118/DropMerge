using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject EndUI;
    [SerializeField] private GameObject PauseUI;
    void Start()
    {
        EndUI.SetActive(false);
        PauseUI.SetActive(false);
    }

    public void EndGame()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = false;
        EndUI.SetActive(true);
    }
}
