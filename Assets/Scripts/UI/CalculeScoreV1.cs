using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CalculeScoreV1 : MonoBehaviour
{
    //public GameManager unManager;

    private List<int> points = new List<int>();
    private List<int> objBroken = new List<int>();

    public float SetResultat;
    //(Points)
    private float GetResultat;
    public float SetResultatMax;
    private float GetResultatMax;

    //Points pour avoir une étoile (et respectivement)
    private float uneEtoile;
    private float deuxEtoile;
    private float troisEtoile;

    [SerializeField] private Image uneEtoileSpawn;
    [SerializeField] private Image deuxEtoileSpawn;
    [SerializeField] private Image troisEtoileSpawn;

    //Couleur de progression avant d'avoir une étoile
    [SerializeField] private Color _nostar;

    [SerializeField] private Color _bronze;
    [SerializeField] private Color _argent;
    [SerializeField] private Color _dore;

    private bool _estBronze = false;
    private bool _estArgent = false;
    private bool _estDore = false;

    public float SetResultats(float result)
    {
        SetResultat = result;                       // Récupère la valeur de résult dans SetResultat
        return SetResultat;                         // Récupère la valeur de la scene vers un script qui est en dehors de la scene, en passant par le GameManager
    }

    public float SetResultatsMax(float resultMax)
    {
        SetResultatMax = resultMax;                 // Récupère la valeur de resultMax dans SetResultatMax
        return SetResultatMax;                      // Récupère la valeur de la scene vers un script qui est en dehors de la scene, en passant par le GameManager
    }

    public void AddPoints(int points)
    {
        GetResultat += points;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetResultat = SetResultats(SetResultat);
        GetResultatMax = SetResultatsMax(SetResultatMax);


        uneEtoile = GetResultatMax / 3;
        deuxEtoile = uneEtoile * 2;
        troisEtoile = GetResultatMax;

        uneEtoileSpawn.rectTransform.localScale = Vector3.zero;
        deuxEtoileSpawn.rectTransform.localScale = Vector3.zero;
        troisEtoileSpawn.rectTransform.localScale = Vector3.zero;
        uneEtoileSpawn.color = _nostar;
    }

    // Update is called once per frame
    void Update()
    {
        //A remplacer par l'ajout des points
        if (Input.GetKeyUp(KeyCode.Space))
        {
            AddPoints(1);
            //print(GetResultat);
        }

        
        if (GetResultat > uneEtoile && GetResultat < deuxEtoile) {
            if (!_estBronze) {
                Bronze();
                _estBronze = true;
            }
            float progressArgent = GetResultat / deuxEtoile;
            deuxEtoileSpawn.rectTransform.localScale = new Vector3(progressArgent, 1, 1);
        } else if (GetResultat > deuxEtoile && GetResultat < troisEtoile) {
            if (!_estArgent) {
                Argent();
                _estArgent = true;
            }
            float progressDore = GetResultat / troisEtoile;
            troisEtoileSpawn.rectTransform.localScale = new Vector3(progressDore, 1, 1);
        } else if (GetResultat < uneEtoile) {
            float progressBronze = GetResultat / uneEtoile;
            uneEtoileSpawn.rectTransform.localScale = new Vector3(progressBronze, 1, 1);
        } else {
            if (!_estDore) {
                Dore();
                _estDore = true;
            }
        }
    }

    //Ces fonctions changent tous les masques d'étoiles en la couleur éponyme
    public void Bronze()
    {
        uneEtoileSpawn.color = _bronze;
        deuxEtoileSpawn.color = _bronze;
        troisEtoileSpawn.color = _bronze;
    }

    public void Argent()
    {
        uneEtoileSpawn.color = _argent;
        deuxEtoileSpawn.color = _argent;
        troisEtoileSpawn.color = _argent;
    }

    public void Dore()
    {
        uneEtoileSpawn.color = _dore;
        deuxEtoileSpawn.color = _dore;
        troisEtoileSpawn.color = _dore;
    }
}
