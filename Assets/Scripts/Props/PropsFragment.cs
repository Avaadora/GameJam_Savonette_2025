using UnityEngine;

public class PropsFragment : MonoBehaviour
{
    public void InitializeFragment()
    {
        // fait qqch (genre effet de particule, sons, scale, etc)
        if (Random.Range(0, 10) == 0)
        {
            Destroy(gameObject);
        }

        Destroy(transform.GetComponent<PropsFragment>()); // delete le script pour opti
    }
}