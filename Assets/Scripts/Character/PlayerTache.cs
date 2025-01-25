using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerTache : MonoBehaviour
{
    [SerializeField] private GameObject myPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaitIAmInTheBathroom()
    {
        var instance = Instantiate(myPrefab);
        var instancePlaneObject = instance.GetComponent<DecalProjector>();           //Il faut trouver autre chose que NetworkObject
        Instantiate(instancePlaneObject);
        yield return new WaitForSeconds(2);
    }
}
