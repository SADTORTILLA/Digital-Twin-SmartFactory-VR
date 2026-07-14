using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Handles start scene UI actions and displays run history.
/// </summary>
public class StartSceneUIController : MonoBehaviour
{
    [Header("Scene Names")]
    [SerializeField] private string scenarioSceneName = "ScenarioScene";

    [Header("Options UI")]
    [SerializeField] private Toggle stepAudioToggle;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private AudioSource musicPreviewSource;

    [Header("Run History UI")]
    [SerializeField] private TextMeshProUGUI runHistoryLabel;
    [SerializeField] private string emptyRunHistoryText = "No runs yet.";
    [SerializeField] private int maxShownRuns = 10;

    private void Start()
    {
        if (stepAudioToggle != null)
        {
            stepAudioToggle.SetIsOnWithoutNotify(GameSettings.StepAudioEnabled);
            stepAudioToggle.onValueChanged.AddListener(OnStepAudioToggleChanged);
        }

        if (musicVolumeSlider != null)
        {
            musicVolumeSlider.SetValueWithoutNotify(GameSettings.MusicVolume);
            musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        }

        ApplyPreviewMusicVolume(GameSettings.MusicVolume);

        RefreshRunHistoryUI();
    }

    private void OnDestroy()
    {
        if (stepAudioToggle != null)
            stepAudioToggle.onValueChanged.RemoveListener(OnStepAudioToggleChanged);

        if (musicVolumeSlider != null)
            musicVolumeSlider.onValueChanged.RemoveListener(OnMusicVolumeChanged);
    }

    [Header("UI Panels")]
    [SerializeField] private GameObject userInfoCanvas;

    public void OnStartButtonPressed()
    {
        if (userInfoCanvas != null)
        {
            userInfoCanvas.SetActive(true);
        }
        else
        {
            // Fallback just in case they didn't assign the canvas
            SceneManager.LoadScene(scenarioSceneName);
        }
    }

    public void OnStepAudioToggleChanged(bool enabled)
    {
        GameSettings.StepAudioEnabled = enabled;
    }

    public void OnMusicVolumeChanged(float volume)
    {
        GameSettings.MusicVolume = volume;
        ApplyPreviewMusicVolume(volume);
    }

    public void OnClearRunHistoryPressed()
    {
        RunHistory.ClearRuns();
        RefreshRunHistoryUI();
    }

    public void RefreshRunHistoryUI()
    {
        if (runHistoryLabel == null)
            return;

        List<float> runs = RunHistory.GetRuns();
        if (runs.Count == 0)
        {
            runHistoryLabel.text = emptyRunHistoryText;
            return;
        }

        var sb = new StringBuilder();
        int count = Mathf.Min(maxShownRuns, runs.Count);

        for (int i = 0; i < count; i++)
        {
            sb.Append(i + 1);
            sb.Append(". ");
            sb.Append(FormatSeconds(runs[i]));
            if (i < count - 1)
                sb.AppendLine();
        }

        runHistoryLabel.text = sb.ToString();
    }

    private static string FormatSeconds(float seconds)
    {
        int totalSeconds = Mathf.FloorToInt(seconds);
        int minutes = totalSeconds / 60;
        int remainingSeconds = totalSeconds % 60;
        return $"{minutes:00}:{remainingSeconds:00}";
    }

    private void ApplyPreviewMusicVolume(float volume)
    {
        if (musicPreviewSource == null)
            return;

        musicPreviewSource.volume = Mathf.Clamp01(volume);
    }
}
