using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class StartupMerge : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    private bool complete = false;
    [SerializeField] private GameObject whitePanel;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mergeable" && !complete)
        {
            complete = true;

            Vector3 mergePos = (collision.transform.position + transform.position) / 2;
            particles.transform.position = mergePos;
            particles.Play();
            whitePanel.GetComponent<PlayableDirector>().Play();
            StartCoroutine(FadeAndSwitch());
        }
    }

    IEnumerator FadeAndSwitch()
    {
        yield return new WaitForSeconds((float)whitePanel.GetComponent<PlayableDirector>().playableAsset.duration);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
