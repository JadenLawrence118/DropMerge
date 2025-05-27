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

    private GameObject dropIndicator;
    [SerializeField] private GameObject[] spawnIndicators;
    private int nextSpawn;

    private int points = 0;
    [SerializeField] private TextMeshProUGUI scoreCounter;

    [SerializeField] private float dropCooldown = 1;
    private bool canDrop = true;

    private void Awake()
    {
        dropIndicator = GameObject.Find("PosIndicator");
        nextSpawn = Random.Range(0, 3);
        Instantiate(spawnIndicators[nextSpawn], dropIndicator.transform);
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && canDrop)
        {
            OnClick();
        }

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 2.0f;
        Vector3 dropPos = Camera.main.ScreenToWorldPoint(mousePos);
        dropPos.y = dropYPos;
        dropIndicator.transform.position = dropPos;
    }

    private void OnClick()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 2.0f;
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
        if (objectPos.x >= dropMinX && objectPos.x <= dropMaxX)
        {
            canDrop = false;
            objectPos.y = dropYPos;
            Instantiate(toSpawn[nextSpawn], objectPos, Quaternion.identity, GameObject.Find("Balls").transform);
            nextSpawn = Random.Range(0, 3);
            Destroy(dropIndicator.transform.GetChild(0).gameObject);
            Instantiate(spawnIndicators[nextSpawn], dropIndicator.transform);
            StartCoroutine(DropCooldown());
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

    IEnumerator DropCooldown()
    {
        yield return new WaitForSeconds(dropCooldown);
        canDrop = true;
    }
}
