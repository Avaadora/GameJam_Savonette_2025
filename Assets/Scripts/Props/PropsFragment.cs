using UnityEngine;

public class PropsFragment : MonoBehaviour
{

    public void InitializeFragment()
    {
        // fait qqch (genre effet de particule, sons, scale, etc)

        Destroy(transform.GetComponent<PropsFragment>()); // delete le script pour opti
    }
}