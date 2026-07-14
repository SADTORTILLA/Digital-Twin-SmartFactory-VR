using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// Central controller for the pharmaceutical labeling scenario.
/// Manages steps, timer, audio, and UI.
/// </summary>
public class StepManager : MonoBehaviour
{
    [System.Serializable]
    public class Step
    {
        public string stepName;
        public AudioClip audioClip;
        public TextMeshProUGUI label;
        public StepCondition condition;
    }

    [Header("Steps")]
    [SerializeField] private List<Step> steps = new List<Step>();

    [Header("Intro Audio")]
    [SerializeField] private AudioClip introAudioClip;

    [Header("Audio Source")]
    [SerializeField] private AudioSource audioSource;

    [Header("Timer UI")]
    [SerializeField] private TextMeshProUGUI timerLabel;

    [Header("Scene Flow")]
    [SerializeField] private string startSceneName = "StartScene";
    [SerializeField] private float returnToStartDelay = 1.25f;

    private static readonly Color ColorPending = Color.white;
    private static readonly Color ColorActive  = Color.green;
    private static readonly Color ColorDone    = new Color(0.6f, 0.6f, 0.6f);

    private int currentStepIndex = -1;
    private float elapsedTime = 0f;
    private bool timerRunning = false;
    private bool scenarioFinished = false;
    
    private List<float> stepTimes = new List<float>();
    private List<int> falseGrabsPerStep = new List<int>();
    private float currentStepStartTime = 0f;
    private int currentStepFalseGrabs = 0;

    // Compatibility property used by StepSpawner and other condition scripts.
    public int CurrentStep => currentStepIndex;

    private void Awake()
    {
        foreach (var step in steps)
        {
            if (step.condition != null)
                step.condition.Initialize(this);
            else
                Debug.LogWarning($"[StepManager] Step '{step.stepName}' has no StepCondition.");
        }
    }

    private void Start()
    {
        foreach (var step in steps)
            SetLabelColor(step, ColorPending);

        UpdateTimerLabel();

        StartCoroutine(PlayIntroThenActivateFirstStep());
    }

    private void Update()
    {
        if (timerRunning && !scenarioFinished)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerLabel();
        }
    }

    public void OnScenarioStarted()
    {
        timerRunning = true;
        AdvanceToNextStep();
    }

    public void OnStepCompleted()
    {
        if (currentStepIndex < 0 || currentStepIndex >= steps.Count)
            return;

        AdvanceToNextStep();
    }

    // Backward-compatible API expected by StepCondition.
    public void StartScenario()
    {
        OnScenarioStarted();
    }

    // Backward-compatible API expected by StepCondition.
    public void CompleteCurrentStep()
    {
        OnStepCompleted();
    }

    private IEnumerator PlayIntroThenActivateFirstStep()
    {
        if (GameSettings.StepAudioEnabled && introAudioClip != null && audioSource != null)
        {
            audioSource.clip = introAudioClip;
            audioSource.Play();
            yield return new WaitForSeconds(introAudioClip.length);
        }

        ActivateStep(0);
    }

    private void AdvanceToNextStep()
    {
        if (currentStepIndex >= 0 && currentStepIndex < steps.Count)
        {
            var current = steps[currentStepIndex];
            current.condition?.TeardownCondition();
            SetLabelColor(current, ColorDone);
            
            float stepDuration = elapsedTime - currentStepStartTime;
            stepTimes.Add(stepDuration);
            falseGrabsPerStep.Add(currentStepFalseGrabs);
            currentStepFalseGrabs = 0;
        }

        int nextIndex = currentStepIndex + 1;

        if (nextIndex >= steps.Count)
        {
            FinishScenario();
            return;
        }

        ActivateStep(nextIndex);
    }

    private void ActivateStep(int index)
    {
        currentStepStartTime = elapsedTime;
        currentStepIndex = index;
        var step = steps[index];

        SetLabelColor(step, ColorActive);

        StartCoroutine(PlayStepAudioThenEnableCondition(step));
    }

    private IEnumerator PlayStepAudioThenEnableCondition(Step step)
    {
        bool wasRunning = timerRunning;
        bool canPlayStepAudio = GameSettings.StepAudioEnabled;

        if (canPlayStepAudio && step.audioClip != null && audioSource != null)
        {
            timerRunning = false;
            audioSource.clip = step.audioClip;
            audioSource.Play();
            yield return new WaitForSeconds(step.audioClip.length);
            timerRunning = wasRunning;
        }

        step.condition?.SetupCondition();
    }

    private void SetLabelColor(Step step, Color color)
    {
        if (step.label != null)
            step.label.color = color;
    }

    private void UpdateTimerLabel()
    {
        if (timerLabel != null)
        {
            int totalSeconds = Mathf.FloorToInt(elapsedTime);
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;
            timerLabel.text = $"{minutes:00}:{seconds:00}";
        }
    }

    private void FinishScenario()
    {
        scenarioFinished = true;
        timerRunning = false;
        RunHistory.AddRun(elapsedTime);
        SessionDataManager.SaveSessionToCSV(elapsedTime, stepTimes, falseGrabsPerStep);
        Debug.Log("[StepManager] Scenario finished.");
        StartCoroutine(ReturnToStartScene());
    }

    private IEnumerator ReturnToStartScene()
    {
        if (returnToStartDelay > 0f)
            yield return new WaitForSeconds(returnToStartDelay);

        SceneManager.LoadScene(startSceneName);
    }

    public void RecordFalseGrab()
    {
        if (timerRunning && !scenarioFinished)
        {
            currentStepFalseGrabs++;
            Debug.Log($"[StepManager] False grab recorded. Total for current step: {currentStepFalseGrabs}");
        }
    }
}
