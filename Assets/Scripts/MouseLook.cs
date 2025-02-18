using UnityEngine;

public class MouseLook : MonoBehaviour {
    [SerializeField] private float sensitivity = 100;

    public Transform cameraTransform;
    public Rigidbody playerBody;

    private float xRotation, yRotation;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update() {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        yRotation += mouseX; 
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        playerBody.MoveRotation(playerBody.rotation * Quaternion.Euler(0f, mouseX, 0f));

        transform.position = cameraTransform.position;
    }
}