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
            GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("musicVol", 1);
            print(PlayerPrefs.GetFloat("musicVol"));
        }
        else if (soundEffect)
        {
            GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SFXVol", 1);
            print(PlayerPrefs.GetFloat("SFXVol"));
        }
    }
}
