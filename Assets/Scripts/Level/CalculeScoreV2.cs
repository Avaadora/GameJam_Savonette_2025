using System.Collections.Generic;
using UnityEngine;

public class CalculeScoreV2 : MonoBehaviour
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
        SetResultat = result;                       // R�cup�re la valeur de r�sult dans SetResultat
        return SetResultat;                         // R�cup�re la valeur de la scene vers un script qui est en dehors de la scene, en passant par le GameManager
    }

    public int SetResultatsMax(int resultMax)
    {
        SetResultatMax = resultMax;                 // R�cup�re la valeur de resultMax dans SetResultatMax
        return SetResultatMax;                      // R�cup�re la valeur de la scene vers un script qui est en dehors de la scene, en passant par le GameManager
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
        if (GetResultat > uneEtoile && GetResultat < deuxEtoile)                // est ce que GetResultat est sup�rieure � 1etoile, mais inferieur � 2etoiles
        {
            print("un");                                                        // Jecrie 1
        }
        else
        {
            if (GetResultat < deuxEtoile && GetResultat < troisEtoile)          // est ce que GetResultat est sup�rieure � 2etoile, mais inferieur � 3etoiles
            {
                print("deux");                                                  // Jecrie 2
            }
            else
            {
                if (GetResultat >= troisEtoile)                                 // est ce que GetResultat est sup�rieure ou �gale � 3etoile
                {
                    print("toix");                                              // Jecrie 3
                }
            }
        }
    }
}