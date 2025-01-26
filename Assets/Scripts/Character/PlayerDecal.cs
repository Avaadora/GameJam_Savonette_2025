using System.Collections;
using UnityEngine;

public class PlayerDecal : MonoBehaviour
{
    [Header("--- Decal Settings ---")]
    [SerializeField] private float cooldown;

    [Header("Components")]
    [SerializeField] private GameObject decal;
    [SerializeField] private Transform player;

    void Start()
    {
        StartCoroutine(InstantiateDecal());
    }

    private IEnumerator InstantiateDecal()
    {
        Instantiate(decal);
        decal.transform.position = player.position;
        yield return new WaitForSeconds(cooldown);
        StartCoroutine(InstantiateDecal());
    }
}