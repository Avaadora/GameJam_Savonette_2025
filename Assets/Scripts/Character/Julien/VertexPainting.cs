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

    public float Speed = 1f;


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
                
            }

            

            /*if(myMesh.HasVertexAttribute() == myPlayerController.mesh.HasVertexAttribute)
            { 
                myPlayerController.Move(groundDrague);
            }
            myMesh.HasVertexAttribute();*/
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
