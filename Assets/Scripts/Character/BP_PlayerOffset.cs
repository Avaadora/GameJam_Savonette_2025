using UnityEngine;

public class BP_PlayerOffset : MonoBehaviour
    {
        
    public Transform player; // Le Transform du joueur
    public Vector3 offset = new Vector3(0, 2, 0); // Offset défini


    // Update is called once per frame
    void Update()
    {
        // Applique l'offset au Particle System
        transform.position = player.position + offset;
    }
}
