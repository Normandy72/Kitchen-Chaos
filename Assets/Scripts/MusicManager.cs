using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance {get; private set;} 

    private const string PLAYER_PREFS_MUSIC_VOLUME = "MusicVolume";
    private float volume = 0.3f;
    private AudioSource audioSource;

    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
        volume = PlayerPrefs.GetFloat(PLAYER_PREFS_MUSIC_VOLUME, 0.3f);
        audioSource.volume = volume;
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

        PlayerPrefs.SetFloat(PLAYER_PREFS_MUSIC_VOLUME, volume);
        PlayerPrefs.Save();
    }

    public float GetVolume()
    {
        return volume;
    }
}
