using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private CalculeScoreV2 unCalculeScore;

    public List<int> pointsPerObject = new List<int>();
    public List<int> objectBrokenable = new List<int>();

    private int resultat;
    public int resultatMax;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < pointsPerObject.Count; i++)
        {
            pointsPerObject[-1] = 0;
            resultat = pointsPerObject[i - 1 + i];
        }
        resultat = resultat * pointsPerObject.Count;
        unCalculeScore.SetResultats(resultat);

        resultatMax = objectBrokenable.Count * pointsPerObject.Count;
        unCalculeScore.SetResultatsMax(resultatMax);
    }
}