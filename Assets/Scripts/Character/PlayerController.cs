using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("--- Player Settings ---")]
    [SerializeField] private float moveSpeed; // vitesse de mouvement
    [SerializeField] private float groundDrag; // friction avec le sol
    [SerializeField] private float jumpForce; // force de jump
    [SerializeField] private float jumpCooldown; // cooldown avant de pouvoir de rejump
    [SerializeField] private float airMultiplier; // air control

    [Header("Références")]
    [SerializeField] private Transform player;
    [SerializeField] private Transform playerOrientation;
    [SerializeField] private BoxCollider playerCollider;
    [SerializeField] private float playerHeight; // taille du joueur (mettre la valeur de scale y)
    [SerializeField] private LayerMask groundLayer; // layer du sol
    private bool canJump = true;
    [HideInInspector] public bool isGrounded = false;
    private bool isWallFront = false;

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
        // isWallFront = Physics.Raycast(player.position, player.forward, player.localScale.z / 2f + 0.2f);

        Inputs();
        SpeedControl();

        // change la friction entre sol et air
        playerRigidbody.linearDamping = isGrounded ? groundDrag : 0f;

        Grounded();

        if ((Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f) && transform.localScale.x > 0.25f)
        {
            transform.localScale -= 0.25f / GameManager.Instance.soapTime * Time.deltaTime * Vector3.one;
        }

    }

    private void Grounded() // ground check
    {
        Vector3 boxCenter = playerCollider.bounds.center;
        Vector3 halfExtents = playerCollider.bounds.extents;

        halfExtents.y = 0.025f;

        float maxDistance = playerCollider.bounds.extents.y;

        isGrounded = Physics.BoxCast(boxCenter, halfExtents, Vector3.down, transform.rotation, maxDistance, groundLayer);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Inputs()
    {
        // inputs de move
        if (!isWallFront)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
        }

        // conditions pour sauter
        if (Input.GetButton("Jump") && canJump && isGrounded)
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