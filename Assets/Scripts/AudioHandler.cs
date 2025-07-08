using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] private bool music = false;
    [SerializeField] private bool soundEffect = false;
    void Start()
    {
        UpdateAudio();
    }

    public void UpdateAudio()
    {
        if (music)
        {
            foreach (AudioSource audio in transform.GetComponents<AudioSource>())
            { 
                audio.volume = PlayerPrefs.GetFloat("musicVol", 1);
            }
        }
        else if (soundEffect)
        {
            foreach (AudioSource audio in transform.GetComponents<AudioSource>())
            { 
                audio.volume = PlayerPrefs.GetFloat("SFXVol", 1);
            }
        }
    }
}
