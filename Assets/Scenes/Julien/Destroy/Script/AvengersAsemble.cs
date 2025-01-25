using System.Threading;
using UnityEngine;

public class AvengersAsemble : MonoBehaviour
{
    [SerializeField] private GameObject unGameObject;
    [SerializeField] private Transform ColliderTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(tag == "Player")
        {
            for (int i = 0; i < unGameObject.transform.childCount; i++)
            {
                Collider collider = ColliderTransform.GetChild(0).GetComponent<Collider>();

                GameObject go = Instantiate(unGameObject, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                go.transform.parent = GameObject.Find("Player").transform;
                print(unGameObject.gameObject.transform.GetChild(i));
            }
            //Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
