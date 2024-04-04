using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DrawLineManager : MonoBehaviour
{
    [SerializeField] int multiplierValue = 10;
    [SerializeField] LineManager lineManager;
    void Start()
    {
        Vertex[] vertexList = DataLoadManager.instance.vertices.Vertices;
        Vertex startVertex = vertexList.ElementAt(0);
        int length = vertexList.Length;

        //Enlarged Vertices
        Vertex[] enlargedVerticeList = Vertex.CreateEnlargedVertices(vertexList, multiplierValue);

        lineManager.GetComponent<LineManager>().ConnectLines(enlargedVerticeList);
    }
}
