using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DrawLineManager : MonoBehaviour
{
    public static DrawLineManager instance { get; private set; }

    [SerializeField] int multiplierValue = 10;
    [SerializeField] LineManager lineManager;

    public Vertex[] enlargedVerticeList;
    
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    void OnEnable()
    {
        Vertex[] vertexList = DataLoadManager.instance.vertices.Vertices;
        //Enlarged Vertices
        enlargedVerticeList = Vertex.CreateEnlargedVertices(vertexList, multiplierValue);
    }

    void Start()
    {
        lineManager.GetComponent<LineManager>().ConnectLines(enlargedVerticeList);
    }
}
