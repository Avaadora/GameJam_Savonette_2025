using UnityEngine;

public class VivaLindependencia : MonoBehaviour
{
    [SerializeField] private GameObject deuxGameObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deuxGameObject.transform.localScale = new Vector3(Random.Range(0.5f, 0.5f), 0, Random.Range(0.75f, 0.75f));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
