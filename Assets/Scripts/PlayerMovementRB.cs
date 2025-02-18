using UnityEngine;

public class PlayerMovementRB : MonoBehaviour {
    
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    [SerializeField] private Rigidbody rb;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask whatIsGround;

    private bool isGrounded;

    private float x, z;

    private void Update() {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        
        if (Input.GetButtonDown("Jump") && isGrounded) {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        }
    }

    private void FixedUpdate() {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, whatIsGround);
        

        Vector3 move = transform.right * x + transform.forward * z;
        rb.linearVelocity = new Vector3(move.x  * moveSpeed, rb.linearVelocity.y, move.z * moveSpeed) ;
    }
}