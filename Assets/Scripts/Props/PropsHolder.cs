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
            // ajoute le script li� aux fragments, automatiquement � tout les fragments enfants + tout ce qu'il a besoin pour collisionner
            transform.GetChild(i).AddComponent<PropsFragment>();
            transform.GetChild(i).AddComponent<MeshCollider>();
            transform.GetChild(i).GetComponent<MeshCollider>().convex = true;
            transform.GetChild(i).AddComponent<Rigidbody>();
            transform.GetChild(i).GetComponent<MeshRenderer>().material = transform.GetComponent<MeshRenderer>().material;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        // g�re le contact uniquement avec le player
        if (collision.transform.CompareTag("Player"))
        {
            // supprime les �l�ments de l'objet unbroken
            Destroy(transform.GetComponent<MeshRenderer>());
            Destroy(transform.GetComponent<Rigidbody>());
            Destroy(transform.GetComponent<MeshCollider>());

            // �xecute ce code pour tout les enfants (fragments)
            for (int i = 0; i < transform.childCount; i++)
            {
                // active le fragment, ajoute une force pour le propulcer, lance sa fonction d'initialisation, retire le fragment de cet objet
                transform.GetChild(i).gameObject.SetActive(true);
                transform.GetChild(i).GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(forceMin, forceMax), Random.Range(forceMin, forceMax), Random.Range(forceMin, forceMax)), ForceMode.Impulse);
                transform.GetChild(i).GetComponent<PropsFragment>().InitializeFragment();
                transform.GetChild(i).parent = null;
            }
            Destroy(gameObject); // destroy cet objet quand il a plus de fragments attach�s pour opti
        }
    }
}
