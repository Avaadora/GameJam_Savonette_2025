using System.Collections.Generic;
using UnityEngine;

public class CalculeScore : MonoBehaviour
{
    public GameManager unManager;

    private List<int> points = new List<int>();
    private List<int> objBroken = new List<int>();

    public int SetResultat;
    private int GetResultat;
    public int SetResultatMax;
    private int GetResultatMax;
    private int uneEtoile;
    private int deuxEtoile;
    private int troisEtoile;

    public GameObject uneEtoileSpawn;
    public GameObject deuxEtoileSpawn;
    public GameObject troixEtoileSpawn;

    public int SetResultats(int result)
    {
        SetResultat = result;               // Récupère la valeur de résult dans SetResultat
        return SetResultat;                 // Récupère la valeur de la scene vers un script qui est en dehors de la scene, en passant par le GameManager
    }

    public int SetResultatsMax(int resultMax)
    {
        SetResultatMax = resultMax;         // Récupère la valeur de resultMax dans SetResultatMax
        return SetResultatMax;              // Récupère la valeur de la scene vers un script qui est en dehors de la scene, en passant par le GameManager
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetResultat = SetResultats(SetResultat);
        GetResultatMax = SetResultatsMax(SetResultatMax);


        uneEtoile = GetResultatMax / 3;
        deuxEtoile = uneEtoile * 2;
        troisEtoile = GetResultatMax;
    }

    // Update is called once per frame
    void Update()
    {
        print(SetResultat);
        if (GetResultat > uneEtoile && GetResultat < deuxEtoile)
        {
            print("un");
        }
        else
        {
            if (GetResultat < deuxEtoile && GetResultat < troisEtoile)
            {
                print("deux");
            }
            else
            {
                if (GetResultat >= troisEtoile)
                {
                    print("toix");
                }
            }
        }
    }
}
