using System.Numerics;
using UnityEngine;

public class PlayerConroller : MonoBehaviour
{
    private const float gravityScale = 9.8f, speedScale = 5f, jumpForce = 8f, turnSpeed = 90f;
    private float verticalSpeed, mouseX, mouseY, currentCameraAngleX;
    private int inversion = -1;
    [SerializeField]
    private GameObject playerCamera;
    [SerializeField]
    private GameObject characterController;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    private void FixedUpdate()
    {
        Rotate();
    }
    void Update()
    {
        Move();
    }
    private void Rotate()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(new UnityEngine.Vector3(0f, mouseX * turnSpeed * Time.fixedDeltaTime, 0f));
        currentCameraAngleX += mouseY * Time.fixedDeltaTime * turnSpeed * inversion;
        currentCameraAngleX = Mathf.Clamp(currentCameraAngleX, -60f, 60f);
        playerCamera.transform.localEulerAngles = new UnityEngine.Vector3(currentCameraAngleX, 0f, 0f);

    }

    private void Move()
    {
        UnityEngine.Vector3 velocity = new UnityEngine.Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        velocity = transform.TransformDirection(velocity)* speedScale;
        if (characterController.isGrounded)
        {
            verticalSpeed = 0f;
            if(Input.GetKeyDown(KeyCode.Space))
            {
                verticalSpeed = jumpForce;
            }
        }
        verticalSpeed -= gravityScale * Time.deltaTime;
        velocity.y = verticalSpeed;
        characterController.Move(velocity * Time.deltaTime);
    }
}
