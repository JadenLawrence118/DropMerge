using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject[] toSpawn;
    [SerializeField] private float dropYPos;
    [SerializeField] private float dropMinX;
    [SerializeField] private float dropMaxX;
    private int points = 0;
    [SerializeField] private TextMeshProUGUI scoreCounter;

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            OnClick();
        }
    }

    private void OnClick()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 2.0f;
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
        if (objectPos.x >= dropMinX && objectPos.x <= dropMaxX)
        {
            objectPos.y = dropYPos;
            Instantiate(toSpawn[0], objectPos, Quaternion.identity, GameObject.Find("Balls").transform);
        }
    }

    public void MergeSpawn(int spawnID, Vector3 objectPos, int mergePoints)
    {
        if (spawnID < toSpawn.Length)
        {
            Instantiate(toSpawn[spawnID], objectPos, Quaternion.identity, GameObject.Find("Balls").transform);
        }
        points += mergePoints;
        scoreCounter.text = "Score: " + points;
    }
}
