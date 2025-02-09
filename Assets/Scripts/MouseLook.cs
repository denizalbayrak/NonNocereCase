using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float lookSensitivity = 1.2f;
    public float smoothFactor = 1.2f;
    private GameObject playerBody;

    private Vector2 mouseLook;
    private Vector2 currentSmoothVelocity;

    private Quaternion initialCameraRotation;
    private Quaternion initialPlayerRotation;

    private void Start()
    {
        playerBody = transform.parent != null ? transform.parent.gameObject : gameObject;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        initialCameraRotation = transform.localRotation;
        initialPlayerRotation = playerBody.transform.localRotation;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        if (mouseX == 0 && mouseY == 0) return;

        var mouseDelta = new Vector2(mouseX, mouseY);
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(lookSensitivity * smoothFactor, lookSensitivity * smoothFactor));

        currentSmoothVelocity.x = Mathf.Lerp(currentSmoothVelocity.x, mouseDelta.x, 1f / smoothFactor);
        currentSmoothVelocity.y = Mathf.Lerp(currentSmoothVelocity.y, mouseDelta.y, 1f / smoothFactor);

        mouseLook += currentSmoothVelocity;

        transform.localRotation = initialCameraRotation * Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        playerBody.transform.localRotation = initialPlayerRotation * Quaternion.AngleAxis(mouseLook.x, Vector3.up);
    }
}

