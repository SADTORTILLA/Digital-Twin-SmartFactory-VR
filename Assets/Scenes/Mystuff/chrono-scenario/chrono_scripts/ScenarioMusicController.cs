using UnityEngine;

/// <summary>
/// Applies saved music volume to a dedicated scenario music source.
/// </summary>
public class ScenarioMusicController : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;

    private void Awake()
    {
        if (musicSource == null)
            musicSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        ApplyVolume();
    }

    public void ApplyVolume()
    {
        if (musicSource == null)
            return;

        musicSource.volume = GameSettings.MusicVolume;
    }
}
