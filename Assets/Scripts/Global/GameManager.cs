using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // singleton
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public float soapTime = 0f;
    public float time = 0f;

    public int destroyableObjectsNumber = 0;
    public int destroyedObjectsNumber = 0;
}