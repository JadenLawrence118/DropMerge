using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroppableCandies : MonoBehaviour
{
    public Image[] droppableImages;
    void Start()
    {
        droppableImages = GetComponentsInChildren<Image>();
        ManualUpdate();
    }

    public void ManualUpdate()
    {
        for (int i = 0; i < droppableImages.Length; i++)
        {
            if ((PlayerPrefs.GetInt("maxDropCandy", 3) - 1) >= i)
            {
                droppableImages[i].gameObject.SetActive(true);
            }
            else
            {
                droppableImages[i].gameObject.SetActive(false);
            }
        }
    }
}
