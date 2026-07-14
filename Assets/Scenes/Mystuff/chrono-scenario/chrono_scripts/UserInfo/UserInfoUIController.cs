using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Attach this to your User Info Canvas or Panel.
/// It collects data from UI elements and saves it to SessionDataManager.
/// </summary>
public class UserInfoUIController : MonoBehaviour
{
    [Header("UI References")]
    public TMP_InputField nameInputField;
    public TMP_Dropdown genderDropdown; // Ensure "Male" and "Female" are set in the inspector
    public TMP_InputField ageInputField;
    public TMP_Dropdown classDropdown; // Ensure predefined classes are set in the inspector
    public Toggle firstTimeUserToggle;

    [Header("Scene Transition")]
    [SerializeField] private string scenarioSceneName = "ScenarioScene";

    public void OnReadyButtonPressed()
    {
        // Save the collected data to the static manager
        if (nameInputField != null)
            SessionDataManager.UserName = nameInputField.text;
        
        if (genderDropdown != null)
            SessionDataManager.Gender = genderDropdown.options[genderDropdown.value].text;
            
        if (ageInputField != null)
            SessionDataManager.Age = ageInputField.text;
            
        if (classDropdown != null)
            SessionDataManager.UserClass = classDropdown.options[classDropdown.value].text;
            
        if (firstTimeUserToggle != null)
            SessionDataManager.IsFirstTime = firstTimeUserToggle.isOn;

        Debug.Log($"[UserInfoUIController] Data saved temporarily: {SessionDataManager.UserName}, {SessionDataManager.Gender}, {SessionDataManager.Age}, {SessionDataManager.UserClass}, First Time: {SessionDataManager.IsFirstTime}");

        // Load the chrono scenario scene
        if (SceneTransitionManager.singleton != null)
        {
            SceneTransitionManager.singleton.GoToSceneAsync(1);
        }
        else
        {
            SceneManager.LoadScene(scenarioSceneName);
        }
    }
}
