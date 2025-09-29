using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MovementAnimation : MonoBehaviour
{
    private Vector3 startPos;
    public float amp;

    void Start()
    {
        startPos = transform.position; // remember where the object starts
    }

    void Update()
    {
        transform.position = startPos + new Vector3(0, Mathf.Sin(Time.time) * amp, 0);
    }
}
