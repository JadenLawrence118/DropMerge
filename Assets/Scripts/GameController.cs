using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject EndUI;
    void Start()
    {
        EndUI.SetActive(false);
    }

    public void EndGame()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = false;
        EndUI.SetActive(true);
    }
}
