using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {
    public float moveSpeed, playerHeight, groundDrag, jumpForce, jumpCooldown, airMultiplier;
    public Transform orientation;
    public LayerMask whatIsGround;
    public KeyCode jumpKey = KeyCode.Space;

    bool grounded, readyToJump = true;
    float horizontalInput, verticalInput;
    Vector3 moveDirection;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update() {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        myInput();
        speedControl();

        if (grounded ) {
            rb.drag = groundDrag;
        } else { 
            rb.drag = 0;
        }
    }

    void FixedUpdate() {
        movePlayer();    
    }

    void myInput() { 
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jumpKey) && readyToJump && grounded) { 
            readyToJump = false;
            jump();
            Invoke(nameof(resetJump), jumpCooldown);
        }
    }

    void movePlayer() { 
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (grounded) {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        } else if (!grounded) {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    void speedControl() {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed) { 
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    void jump() {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    void resetJump() { 
        readyToJump = true;
    }
}
