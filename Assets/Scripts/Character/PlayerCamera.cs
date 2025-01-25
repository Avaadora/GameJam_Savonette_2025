using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [Header("--- Camera Settings ---")]
    [SerializeField] private float rotationSpeed; // vitesse de rotation de la cam
    [SerializeField] private CameraStyle currentStyle; // type de caméra libre ou fixe
    public enum CameraStyle
    {
        Freeview,
        Locked
    }

    [Header("References")]
    // player
    [SerializeField] private Transform player;
    [SerializeField] private Transform playerMesh;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private Transform playerOrientation;
    [SerializeField] private Transform lookAt;

    // cameras
    [SerializeField] private GameObject freeviewCamera;
    [SerializeField] private GameObject lockedCamera;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // change l'orientation du player
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        playerOrientation.forward = viewDir.normalized;

        // change la rotation du player
        if(currentStyle == CameraStyle.Freeview)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 inputDir = playerOrientation.forward * verticalInput + playerOrientation.right * horizontalInput;

            if (inputDir != Vector3.zero)
            {
                playerMesh.forward = Vector3.Slerp(playerMesh.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
            }
        }
        else if(currentStyle == CameraStyle.Locked)
        {
            Vector3 dirToCombatLookAt = lookAt.position - new Vector3(transform.position.x, lookAt.position.y, transform.position.z);
            playerOrientation.forward = dirToCombatLookAt.normalized;

            playerMesh.forward = dirToCombatLookAt.normalized;
        }
    }
}
