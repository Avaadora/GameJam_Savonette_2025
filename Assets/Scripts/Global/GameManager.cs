using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<int> points = new List<int>();
    private List<int> objBroken = new List<int>();

    private int resultat;
    private int resultatMax;
    private int uneEtoile;
    private int deuxEtoile;
    private int troisEtoile;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resultatMax = objBroken.Count / points.Count;

        uneEtoile = resultatMax / 3;
        deuxEtoile = uneEtoile * 2;
        troisEtoile = resultatMax;

        for (int i = 0; i < points.Count; i++)
        {
            points[i - 1] = 0;
            resultat = points[i-1] + points[i];
        }
        resultat = resultat / points.Count;

    }

    // Update is called once per frame
    void Update()
    {
        if(resultat > uneEtoile && resultat < deuxEtoile)
        {

        }
        else
        {
            if(resultat< deuxEtoile && resultat < troisEtoile)
            {

            }
            else
            {

            }
        }
    }
}
