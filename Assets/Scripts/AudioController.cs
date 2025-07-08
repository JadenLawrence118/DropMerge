using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private static AudioController self;

    [SerializeField] private AudioSource menuMusicStart;
    [SerializeField] private AudioSource menuMusic;
    [SerializeField] private AudioSource gameMusicStart;
    [SerializeField] private AudioSource gameMusic;

    [SerializeField] private float pausePitch = 0.8f;
    private float originalPitch;

    private IEnumerator menuWait;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (self == null)
        {
            self = this;
        }
        else
        {
            Destroy(gameObject);
        }

        originalPitch = gameMusic.pitch;
    }

    public void GamePause()
    {
        gameMusic.pitch = pausePitch;
    }
    public void GameResume()
    {
        gameMusic.pitch = originalPitch;
    }
    public void GameStart()
    {
        StopCoroutine(menuWait);

        if (!gameMusic.isPlaying)
        {
            foreach (AudioSource audio in transform.GetComponents<AudioSource>())
            {
                audio.Stop(); 
            }

            gameMusicStart.Play();
            StartCoroutine(WaitForAudioClip(gameMusicStart, gameMusic));
        }
        gameMusic.pitch = originalPitch;
    }

    public void MenuStart()
    {
        if (!menuMusic.isPlaying && !menuMusicStart.isPlaying)
        {
            foreach (AudioSource audio in transform.GetComponents<AudioSource>())
            {
                audio.Stop();
            }

            menuMusicStart.Play();
            menuWait = WaitForAudioClip(menuMusicStart, menuMusic);
            StartCoroutine(menuWait);
        }
    }

    public IEnumerator WaitForAudioClip(AudioSource firstAudio, AudioSource secondAudio)
    {
        yield return new WaitForSeconds(firstAudio.clip.length - 0.2f);
        secondAudio.Play();
    }
}
