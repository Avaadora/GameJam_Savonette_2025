using Unity.VisualScripting;
using UnityEngine;

public class PropsHolder : MonoBehaviour
{
    [Header("--- Props Settings ---")]
    [SerializeField] private float forceMin; // force min à appliquer aléatoirement sur les fragments
    [SerializeField] private float forceMax; // force max à appliquer aléatoirement sur les fragments

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).AddComponent<PropsFragment>(); // ajoute le script lié aux fragments, automatiquement à tout les fragments enfants
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        // gère le contact uniquement avec le player
        if (collision.transform.CompareTag("Player"))
        {
            // éxecute ce code pour tout les enfants (fragments)
            for (int i = 0; i < transform.childCount; i++)
            {
                // active le collider, active le rb, ajoute une force pour propulcer le fragment, lance sa fonction d'initialisation, retire le fragment de cet objet
                transform.GetChild(i).GetComponent<Collider>().enabled = true;
                transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
                transform.GetChild(i).GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(forceMin, forceMax), Random.Range(forceMin, forceMax), Random.Range(forceMin, forceMax)), ForceMode.Impulse);
                transform.GetChild(i).GetComponent<PropsFragment>().InitializeFragment();
                transform.GetChild(i).parent = null;
            }
            Destroy(gameObject); // destroy cet objet quand il a plus de fragments attachés pour opti
        }
    }
}
