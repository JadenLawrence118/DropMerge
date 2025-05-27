using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Merge : MonoBehaviour
{
    public int MergeID;
    private bool running = false;
    [SerializeField] private int mergePoints;
    private GameController controller;
    private PlayerController player;

    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    private void Update()
    {
        if (transform.position.y > player.dropYPos)
        {
            controller.EndGame();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!running)
        {
            if (collision.gameObject.tag == gameObject.tag && collision.gameObject.GetComponent<Merge>().MergeID == MergeID)
            {
                if (transform.GetSiblingIndex() > collision.transform.GetSiblingIndex())
                {
                    running = true;
                    Vector3 mergePos = (collision.transform.position + transform.position) / 2;
                    Destroy(collision.gameObject);
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().MergeSpawn(MergeID + 1, mergePos, mergePoints);
                    Destroy(gameObject);
                }
            }
        }
    }
}
