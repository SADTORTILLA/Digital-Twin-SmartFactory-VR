using UnityEngine;

public class CuttableObject : MonoBehaviour
{
    [Header("Part To Remove")]
    [SerializeField] private GameObject excessPlastic;

    public void Process()
    {
        if (excessPlastic != null)
        {
            excessPlastic.SetActive(false);
        }
    }
}