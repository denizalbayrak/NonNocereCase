using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float fixedHeight = 1.25f;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); 
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDir = (transform.forward * vertical) + (transform.right * horizontal);

        moveDir *= moveSpeed;
        controller.Move(moveDir * Time.deltaTime);

        if (Mathf.Abs(transform.position.y - fixedHeight) > 0.001f)
        {
            transform.position = new Vector3(
                transform.position.x,
                fixedHeight,
                transform.position.z
            );
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
