using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerTache : MonoBehaviour
{
    [SerializeField] private GameObject myPrefab;

    private IEnumerator coroutine;
    private Transform followTarget;
    [SerializeField] private PlayerController ourPlayerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //followTarget = transform;
        followTarget = ourPlayerController.transform;
        coroutine = WaitIAmInTheBathroom(2.0f);
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaitIAmInTheBathroom(float waitTime)
    {
        Instantiate(myPrefab);
        myPrefab.transform.position = ourPlayerController.transform.position;
        yield return new WaitForSeconds(waitTime);
        coroutine = WaitIAmInTheBathroom(2.0f);
        StartCoroutine(coroutine);
    }
}