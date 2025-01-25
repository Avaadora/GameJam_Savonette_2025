using System.Collections.Generic;
using UnityEngine;

public class CalculeScore : MonoBehaviour
{
    public GameManager unManager;

    private List<int> points = new List<int>();
    private List<int> objBroken = new List<int>();

    private int total;
    private int resultatMax;
    private int uneEtoile;
    private int deuxEtoile;
    private int troisEtoile;

    private GameObject uneEtoileSpawn;
    private GameObject deuxEtoileSpawn;
    private GameObject troixEtoileSpawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetUneEtoileSpawn()
    {
        Instantiate(uneEtoileSpawn);
    }

    public void GetDeuxEtoileSpawn()
    {
        Instantiate(deuxEtoileSpawn);
    }

    public void GetTroixEtoileSpawn()
    {
        Instantiate(troixEtoileSpawn);
    }
}
