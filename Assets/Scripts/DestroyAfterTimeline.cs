using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class DestroyAfterTimeline : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(FadeAndSwitch());
    }

    IEnumerator FadeAndSwitch()
    {
        yield return new WaitForSeconds((float)GetComponent<PlayableDirector>().playableAsset.duration);
        Destroy(gameObject);
    }
}
