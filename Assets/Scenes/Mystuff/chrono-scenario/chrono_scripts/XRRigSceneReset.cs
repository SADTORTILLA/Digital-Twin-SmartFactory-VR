using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Resets a persistent XR rig position/rotation when a new scene is loaded.
/// If a GameObject tagged "PlayerSpawn" exists in the loaded scene, it is used.
/// Otherwise a fallback transform can be assigned in the inspector.
/// </summary>
public class XRRigSceneReset : MonoBehaviour
{
    [Header("Fallback Spawn (Optional)")]
    [SerializeField] private Transform defaultSpawnPoint;

    [Header("Spawn Tag")]
    [SerializeField] private string playerSpawnTag = "PlayerSpawn";

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (TryMoveToTaggedSpawn())
            return;

        if (defaultSpawnPoint != null)
            transform.SetPositionAndRotation(defaultSpawnPoint.position, defaultSpawnPoint.rotation);
    }

    private bool TryMoveToTaggedSpawn()
    {
        if (string.IsNullOrWhiteSpace(playerSpawnTag))
            return false;

        GameObject spawn = GameObject.FindGameObjectWithTag(playerSpawnTag);
        if (spawn == null)
            return false;

        Transform spawnTransform = spawn.transform;
        transform.SetPositionAndRotation(spawnTransform.position, spawnTransform.rotation);
        return true;
    }
}
