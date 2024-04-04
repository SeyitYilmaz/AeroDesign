using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateModel : MonoBehaviour
{
    private Vertex[] _vertices = DataLoadManager.instance.vertices.Vertices;

    [SerializeField] private int edgeAmount = 5; 
    [SerializeField] private GameObject edgeObject;
    void Start()
    {
        CreateEdges();
    }

    private void ConnectVertices()
    {
        
    }

    private List<Vertex[]> GenerateNewEdges(int totalEdgeAmount)
    {
        int zValue = 0;
        List<Vertex[]> vertexList = new List<Vertex[]>();
        for (int i = 0; i < totalEdgeAmount; i++)
        {
            vertexList.Add(Vertex.CreateVerticeInstance(_vertices, zValue));
            zValue += 10;
        }
        return vertexList;
    }

    private void CreateEdges()
    {
        List<Vertex[]> generatedVertices = GenerateNewEdges(edgeAmount);

        for (int i = 0; i < edgeAmount; i++)
        {
            GameObject edgeGo = Instantiate(edgeObject);
            edgeGo.GetComponent<LineManager>().ConnectLines(generatedVertices[i]);
        }
        

    }
}
