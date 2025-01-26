using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerDecal : MonoBehaviour
{
    [Header("--- Decal Settings ---")]
    [SerializeField] private float cooldown;
    [SerializeField] private Material[] decalTextures;

    [Header("Components")]
    [SerializeField] private GameObject decal;
    [SerializeField] private Transform spawn;
    [SerializeField] private PlayerController playerController;

    void Start()
    {
        StartCoroutine(InstantiateDecal());
    }

    private IEnumerator InstantiateDecal()
    {
        if (playerController.isGrounded)
        {
            Instantiate(decal);
            decal.GetComponent<DecalProjector>().material = decalTextures[Random.Range(0, decalTextures.Length)];
            decal.transform.SetPositionAndRotation(spawn.position, Quaternion.Euler(90f, Random.Range(-180f, 180f), 0f));
            decal.GetComponent<DecalProjector>().size = new Vector3(Random.Range(1.5f, 3.5f), Random.Range(1f, 2.5f), 0.1f);
        }
        yield return new WaitForSeconds(cooldown);
        StartCoroutine(InstantiateDecal());
    }
}