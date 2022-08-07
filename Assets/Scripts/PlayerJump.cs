using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 playerVelocity;
    private bool playerIsGrounded;
    public float jumpHeight = 1f;
    public float gravityValue = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        playerIsGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (playerIsGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && playerIsGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }
}
