using Unity.VisualScripting;
using UnityEngine;

public class PropsHolder : MonoBehaviour
{
    [Header("--- Props Settings ---")]
    [SerializeField] private float forceMin; // force min � appliquer al�atoirement sur les fragments
    [SerializeField] private float forceMax; // force max � appliquer al�atoirement sur les fragments

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).AddComponent<PropsFragment>(); // ajoute le script li� aux fragments, automatiquement � tout les fragments enfants
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        // g�re le contact uniquement avec le player
        if (collision.transform.CompareTag("Player"))
        {
            // �xecute ce code pour tout les enfants (fragments)
            for (int i = 0; i < transform.childCount; i++)
            {
                // active le collider, active le rb, ajoute une force pour propulcer le fragment, lance sa fonction d'initialisation, retire le fragment de cet objet
                transform.GetChild(i).GetComponent<Collider>().enabled = true;
                transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
                transform.GetChild(i).GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(forceMin, forceMax), Random.Range(forceMin, forceMax), Random.Range(forceMin, forceMax)), ForceMode.Impulse);
                transform.GetChild(i).GetComponent<PropsFragment>().InitializeFragment();
                transform.GetChild(i).parent = null;
            }
            Destroy(gameObject); // destroy cet objet quand il a plus de fragments attach�s pour opti
        }
    }
}
