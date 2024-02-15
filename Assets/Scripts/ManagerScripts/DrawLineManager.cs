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
        VertexList vertexList = DataLoadManager.instance.vertices;
        Vertex startVertex = vertexList.Vertices[0];
        int length = vertexList.Vertices.Length;

        //Enlarged Vertices
        VertexList enlargedVerticeList = new VertexList
        {
            Vertices = vertexList.Vertices.Select(v=> new Vertex { x = v.x * multiplierValue,
            y = v.y * multiplierValue}).ToArray()
        };

        lineManager.GetComponent<LineManager>().ConnectLines(enlargedVerticeList);
    }
}
