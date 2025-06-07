using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FadeOutHandler : MonoBehaviour
{
    public GameObject fadeToWhite;
    void Start()
    {
        fadeToWhite.SetActive(false);
    }

    public void FadeOut()
    {
        fadeToWhite.SetActive(true);
        fadeToWhite.GetComponent<PlayableDirector>().Play();
    }
}
