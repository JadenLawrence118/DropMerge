using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class StartupMerge : MonoBehaviour
{
    [SerializeField] private bool mergeStarter = false;
    [SerializeField] private AudioSource fallSound;
    [SerializeField] private AudioSource mergeSound;

    private void Start()
    {
        GameObject.FindGameObjectWithTag("ThemeController").GetComponent<ThemeController>().UpdateTheme(PlayerPrefs.GetInt("theme", -1));
    }

    [SerializeField] private ParticleSystem particles;
    private bool complete = false;
    [SerializeField] private GameObject whitePanel;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        fallSound.Stop();
        mergeSound.Play();

        if (collision.gameObject.tag == "Mergeable" && !complete && mergeStarter)
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
