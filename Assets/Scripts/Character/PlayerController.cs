using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Components")]
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _orientation;

    [Header("Player Move")]
    [SerializeField][Range(0.0f, 200.0f)] private float _speed = 50.0f;
    private Vector3 _moveDirection;
    private float _horizontalInput = 0.0f; // input x (Q / D)
    private float _verticalInput = 0.0f; // input y (Z / S)

    [Header("Player Jump")]
    [SerializeField] private float _jumpForce = 1.0f;
    [SerializeField] private float _jumpCooldown = 1.0f;
    [SerializeField] private float _airMultiplier = 1.0f;
    [SerializeField] private LayerMask _groundLayer;
    private bool _canJump = true;
    private bool _isGrounded = false;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        // _rigidbody.freezeRotation = true;
    }


    private void FixedUpdate()
    {
        _horizontalInput = Input.GetAxis("Horizontal"); // get input x (-1 to 1)
        _verticalInput = Input.GetAxis("Vertical"); // get input y (-1 to 1)
        _isGrounded = Physics.Raycast(transform.position - new Vector3(0.0f, transform.localScale.y / 2.0f, 0.0f), Vector3.down, 0.1f, _groundLayer); // check si player au sol (appliquer layer "ground" sur les objets où il peut sauter)

        PlayerMove();
        PlayerJump();

        // application des forces
        _rigidbody.AddForce(_moveDirection.normalized * _speed, ForceMode.Force);
    }

    private void PlayerMove() // gère les mouvements du player
    {
        _moveDirection = _orientation.forward * _verticalInput + _orientation.right * _horizontalInput; // get direction du player

        // gère la vélocité
        Vector3 flatVel = new (_rigidbody.linearVelocity.x, 0f, _rigidbody.linearVelocity.z);
        if (flatVel.magnitude > _speed)
        {
            Vector3 limitedVel = flatVel.normalized * _speed;
            _rigidbody.linearVelocity = new (limitedVel.x, _rigidbody.linearVelocity.y, limitedVel.z);
        }
        _rigidbody.linearDamping = _isGrounded ? 5.0f : 0.0f;
    }

    private void PlayerJump() // gère le saut du player
    {
        if (!_isGrounded) // si player dans les airs
        {
            _speed *= _airMultiplier; // modifier air control
            _moveDirection += (_moveDirection.y < 0 ? Physics.gravity * 3 : Physics.gravity) * Time.deltaTime; // retomber plus vite
        }

        if (Input.GetButton("Jump") && _isGrounded && _canJump)
        {
            _canJump = false;
            _rigidbody.linearVelocity = new Vector3(_rigidbody.linearVelocity.x, 0f, _rigidbody.linearVelocity.z);
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
            Invoke(nameof(ResetJump), _jumpCooldown);
        }
    }
    private void ResetJump()
    {
        _canJump = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position - new Vector3(0.0f, transform.localScale.y / 2.0f, 0.0f), transform.position - new Vector3(0.0f, transform.GetComponent<BoxCollider>().size.y / 2.0f - 0.1f, 0.0f));
    }
}