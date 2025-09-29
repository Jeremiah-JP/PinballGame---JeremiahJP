using UnityEngine;

public class PinballCamera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    Transform ballTransform;
    [SerializeField]
    float smoothVal;
    Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        Vector3 target = ballTransform.position;
        target.z = -10;
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, smoothVal);
        //transform.rotation = Quaternion.identity;
    }
}
