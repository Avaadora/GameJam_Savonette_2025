using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform _orientation;
    [SerializeField] private Transform _player;
    [SerializeField] private float _rotationSpeed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // lock le curseur au centre de l'écran
        Cursor.visible = false; // cache le curseur
    }

    private void LateUpdate()
    {
        Vector3 viewDir = _player.position - new Vector3(transform.position.x, _player.position.y, transform.position.z);
        _orientation.forward = viewDir.normalized;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = _orientation.forward * verticalInput + _orientation.right * horizontalInput;

        if (inputDir != Vector3.zero)
        {
            _player.forward = Vector3.Slerp(_player.forward, inputDir.normalized, _rotationSpeed * Time.deltaTime);
        }
    }
}
