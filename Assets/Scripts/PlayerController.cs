using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject[] toSpawn;

    public float dropYPos;
    [SerializeField] private float[] minXArray;
    [SerializeField] private float[] MaxXArray;
    [SerializeField] private float dropMinY;
    [SerializeField] private float dropMaxY;

    private float dropMinX;
    private float dropMaxX;

    private bool canDrop = false;

    [SerializeField] private GameObject dropIndicator;
    [SerializeField] private GameObject posIndicator;
    [SerializeField] private GameObject[] spawnIndicators;
    private int next1;

    private GameObject nextIndicator;
    private int next2;

    public int points = 0;
    [SerializeField] private TextMeshProUGUI scoreCounter;

    private bool onCooldown = false;

    [SerializeField] private GameObject hold;
    [SerializeField] private int holdID;

    private void Awake()
    {
        next1 = Random.Range(0, PlayerPrefs.GetInt("maxDropCandy", 3));
        Instantiate(spawnIndicators[next1], posIndicator.transform);

        nextIndicator = GameObject.Find("NextUI");
        next2 = Random.Range(0, PlayerPrefs.GetInt("maxDropCandy", 3));
        Instantiate(spawnIndicators[next2], nextIndicator.transform);

        dropMinX = minXArray[PlayerPrefs.GetInt("JarNo", 0)];
        dropMaxX = MaxXArray[PlayerPrefs.GetInt("JarNo", 0)];
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && !onCooldown && canDrop)
        {
            OnClick();
        }

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 2.0f;
        Vector3 dropPos = Camera.main.ScreenToWorldPoint(mousePos);

        if (dropPos.y > dropMinY && dropPos.y < dropMaxY)
        {
            dropPos.y = dropYPos;
            if (dropPos.x > dropMinX && dropPos.x < dropMaxX)
            {
                canDrop = true;
                dropIndicator.transform.position = dropPos;
            }
            else
            {
                canDrop = false;
            }
        }
        else
        {
            canDrop = false;
        }
    }

    private void OnClick()
    {
        onCooldown = true;
        Instantiate(toSpawn[next1], posIndicator.transform.position, Quaternion.identity, GameObject.Find("Balls").transform);
        NewBall();
    }

    public void NewBall()
    {
        next1 = next2;
        next2 = Random.Range(0, PlayerPrefs.GetInt("maxDropCandy", 3));
        Destroy(posIndicator.transform.GetChild(0).gameObject);
        Instantiate(spawnIndicators[next1], posIndicator.transform);
        Destroy(nextIndicator.transform.GetChild(0).gameObject);
        Instantiate(spawnIndicators[next2], nextIndicator.transform);
        nextIndicator.transform.GetChild(0).gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        StartCoroutine(DropCooldown());
    }

    public void MergeSpawn(int spawnID, Vector3 objectPos, int mergePoints)
    {
        if (spawnID < toSpawn.Length)
        {
            Instantiate(toSpawn[spawnID], objectPos, Quaternion.identity, GameObject.Find("Balls").transform);
        }
        points += mergePoints;
        scoreCounter.text = "Score:\n" + points;
    }

    IEnumerator DropCooldown()
    {
        yield return new WaitForSeconds(PlayerPrefs.GetFloat("dropDelay", 0.5f));
        onCooldown = false;
    }

    public void Hold()
    {
        if (hold.transform.childCount == 0)
        {
            holdID = next1;
            Instantiate(spawnIndicators[next1], hold.transform);
            NewBall();
        }
        else
        {
            Destroy(hold.transform.GetChild(0).gameObject);
            Instantiate(spawnIndicators[next1], hold.transform);
            int transfer = next1;
            next1 = holdID;
            holdID = transfer;
            Destroy(posIndicator.transform.GetChild(0).gameObject);
            Instantiate(spawnIndicators[next1], posIndicator.transform);
        }
    }
}
