using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class VertexPainting : MonoBehaviour
{
    private PlayerController myPlayerController;
    private GameObject myObjet;
    //public void SetColors(Color[] inColors);
    private VertexPainting myVertex;
    private BoxCollider myBoxCollider;
    private Mesh myMesh;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //myVertex.OnCollisionEnter();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (myObjet.CompareTag("Player"))
        {
            //myMesh = GetComponent<MeshFilter>().mesh;
            //myPlayerController.Update();
            for (int i = 0; i < myMesh.vertexCount; i++)
            {
                //new myMesh.vertexCount;
                //myMesh.GetVertexAttribute<VertexPainting>();
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
