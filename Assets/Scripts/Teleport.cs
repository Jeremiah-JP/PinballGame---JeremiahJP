using UnityEngine;
using UnityEngine.Apple;

public class Teleport : MonoBehaviour
{

    [SerializeField] private Transform destination;
    public Transform GetDestination()
    {
    return destination;
    }
}
