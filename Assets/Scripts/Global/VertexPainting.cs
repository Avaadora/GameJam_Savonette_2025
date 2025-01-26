using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class VertexPainting : MonoBehaviour
{
    [SerializeField] private PlayerController myPlayerController;
    [SerializeField] private Color myRed;
    [SerializeField] private Color myWhite;
    /*private Mesh mesh;
    private Vector3[] vertices;*/

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (myPlayerController.CompareTag("Player"))
        {
            Mesh mesh = GetComponent<MeshFilter>().mesh;
            Vector3[] vertices = mesh.vertices;

            // crée un nouveau tableau de couleurs où les couleurs seront créées.
            Color[] colors = new Color[vertices.Length];

            for (int i = 0; i < vertices.Length; i++)
            {
                colors[i] = Color.Lerp(Color.red, Color.white, vertices[i].y);
            }
            // affecter le tableau de couleurs au Mesh .
            mesh.colors = colors;
        }
        


        /*mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;

        Color[] colors = new Color[vertices.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            colors[i] = Color.Lerp(myRed, myWhite, vertices[i].y);
        }
        mesh.colors = colors;*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
