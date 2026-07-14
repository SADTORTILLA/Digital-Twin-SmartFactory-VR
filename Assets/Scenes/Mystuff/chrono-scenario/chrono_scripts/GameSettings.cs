using UnityEngine;

/// <summary>
/// Persistent settings shared across scenes.
/// </summary>
public static class GameSettings
{
    private const string StepAudioEnabledKey = "settings.step_audio_enabled";
    private const string MusicVolumeKey = "settings.music_volume";

    public static bool StepAudioEnabled
    {
        get => PlayerPrefs.GetInt(StepAudioEnabledKey, 1) == 1;
        set
        {
            PlayerPrefs.SetInt(StepAudioEnabledKey, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }

    public static float MusicVolume
    {
        get => PlayerPrefs.GetFloat(MusicVolumeKey, 1f);
        set
        {
            float clamped = Mathf.Clamp01(value);
            PlayerPrefs.SetFloat(MusicVolumeKey, clamped);
            PlayerPrefs.Save();
        }
    }
}
