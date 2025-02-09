using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    public float rotationSpeed = 70f; 
    private Quaternion initialRotation; 

    void Start()
    {
        initialRotation = transform.rotation; 
    }

    void Update()
    {
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.J)) horizontal = -1f; // Rotate left
        if (Input.GetKey(KeyCode.L)) horizontal = 1f;  // Rotate right
        if (Input.GetKey(KeyCode.I)) vertical = -1f;   // Rotate up
        if (Input.GetKey(KeyCode.K)) vertical = 1f;    // Rotate down

        transform.Rotate(Vector3.up * horizontal * rotationSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.right * vertical * rotationSpeed * Time.deltaTime, Space.World);
    }

    public void ResetRotation()
    {
        transform.rotation = initialRotation; 
    }
}
