using UnityEngine;

/// <summary>
/// Attach to any GameObject in Scene 1.
/// Controls showing and hiding the options canvas.
/// </summary>
public class OptionsPanel : MonoBehaviour
{
    [Header("References")]
    public GameObject optionsCanvas;
    public GameObject mainCanvas;

    public void OpenOptions()
    {
        optionsCanvas.SetActive(true);
        mainCanvas.SetActive(false);
    }

    public void CloseOptions()
    {
        optionsCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }
}