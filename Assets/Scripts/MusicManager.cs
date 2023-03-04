using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance {get; private set;} 

    private float volume = 0.3f;
    private AudioSource audioSource;

    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeVolume()
    {
        volume += 0.1f;

        //volume = volume % 1.1f;

        if(volume > 1f)
        {
            volume = 0f;
        }

        audioSource.volume = volume;
    }

    public float GetVolume()
    {
        return volume;
    }
}
