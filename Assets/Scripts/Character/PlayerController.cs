//using System.Collections;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    [Header("--- Player Settings ---")]
    [SerializeField] private float moveSpeed; // vitesse de mouvement
    [SerializeField] private float groundDrag; // friction avec le sol
    [SerializeField] private float jumpForce; // force de jump
    [SerializeField] private float jumpCooldown; // cooldown avant de pouvoir de rejump
    [SerializeField] private float airMultiplier; // air control

    [Header("Références")]
    [SerializeField] private Transform playerOrientation;
    [SerializeField] private float playerHeight; // taille du joueur (mettre la valeur de scale y)
    [SerializeField] private LayerMask groundLayer; // layer du sol
    private bool canJump = true;
    private bool isGrounded = false;

    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDirection;
    private Rigidbody playerRigidbody;

    

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerRigidbody.freezeRotation = true;
    }

    private void Update()
    {
        // ground check
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, groundLayer);

        Inputs();
        SpeedControl();

        // change la friction entre sol et air
        playerRigidbody.linearDamping = isGrounded ? groundDrag : 0f;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Inputs()
    {
        // inputs de move
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // conditions pour sauter
        if(Input.GetButton("Jump") && canJump && isGrounded)
        {
            canJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void Move()
    {
        // calcule la direction du mouvement
        moveDirection = playerOrientation.forward * verticalInput + playerOrientation.right * horizontalInput;

        // gestion du air control
        if(isGrounded) // au sol
        {
            playerRigidbody.AddForce(10f * moveSpeed * moveDirection.normalized, ForceMode.Force);
        }
        else if(!isGrounded) // dans les air
        {
            playerRigidbody.AddForce(10f * airMultiplier * moveSpeed * moveDirection.normalized, ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new(playerRigidbody.linearVelocity.x, 0f, playerRigidbody.linearVelocity.z);

        // limite la vélocité
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            playerRigidbody.linearVelocity = new Vector3(limitedVel.x, playerRigidbody.linearVelocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        playerRigidbody.linearVelocity = new Vector3(playerRigidbody.linearVelocity.x, 0f, playerRigidbody.linearVelocity.z);
        playerRigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        canJump = true;
    }

    
}