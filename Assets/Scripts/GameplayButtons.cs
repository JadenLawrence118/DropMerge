using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayButtons : MonoBehaviour
{
    private PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void Hold()
    {
        playerController.Hold();
    }
}
