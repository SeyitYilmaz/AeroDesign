using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    [SerializeField] private Vertex[] vertices;
    [SerializeField] private Vertex[] allVertices;
    [SerializeField] private int[] triangles;
    [SerializeField] private int edgeAmount = 5; 
    [SerializeField] private GameObject edgeObject;
    private List<Vertex[]> generatedVertices;
    private int totalVertexCount = 0;
    

    private Mesh planeMesh;

    private void Awake()
    {
        planeMesh = new Mesh();
        GetComponent<MeshFilter>().mesh = planeMesh;
    }

    void Start()
    {
        vertices = DrawLineManager.instance.enlargedVerticeList;
        allVertices = new Vertex[(vertices.Length+1) * (edgeAmount+1)];
        totalVertexCount = vertices.Length * edgeAmount;
        triangles = new int[edgeAmount * vertices.Length * 6];
        CreateEdges();
        ConnectVertices();
    }

    private void ConnectVertices()
    {
        int verticeLength = vertices.Length;
        int trisAmount = 0;
        int vertexAmount = 0;
        for (int i = 0; i < edgeAmount; i++)
        {
            for (int j = 0; j < verticeLength; j++)
            {
                triangles[trisAmount] = vertexAmount;
                triangles[trisAmount + 1] = vertexAmount + verticeLength + 1;
                triangles[trisAmount + 2] = vertexAmount + 1;
                triangles[trisAmount + 3] = vertexAmount + 1;
                triangles[trisAmount + 4] = vertexAmount + verticeLength + 1;
                triangles[trisAmount + 5] = vertexAmount + verticeLength + 2;
                trisAmount += 6;
                vertexAmount++;
                Debug.Log(vertexAmount);
            }
        }

        Vector3[] allMeshVertices = new Vector3[allVertices.Length + 1];
        for (int i = 0; i < totalVertexCount; i++)
        {
            allMeshVertices[i] = new Vector3(allVertices[i].x, allVertices[i].y, allVertices[i].z);
        }
        planeMesh.Clear();
        planeMesh.vertices = allMeshVertices;
        planeMesh.triangles = triangles;
    }

    private List<Vertex[]> GenerateNewEdges(int totalEdgeAmount)
    {
        int zValue = 0;
        List<Vertex[]> vertexList = new List<Vertex[]>();
        for (int i = 0; i < totalEdgeAmount; i++)
        {
            vertexList.Add(Vertex.CreateVerticeInstance(vertices, zValue));
            zValue += 10;
        }
        return vertexList;
    }

    private void CreateEdges()
    {
        generatedVertices = GenerateNewEdges(edgeAmount);
        int indexCounter = 0;
        //Üçgen oluştururken bütün vertexleri tekrarlanmayan indexlerde tutmak gerekiyordu
        //bu yüzden tek bir dizide toplamak mantıklı geldi
        for (int j = 0; j < edgeAmount; j++)
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                allVertices[indexCounter] = generatedVertices.ElementAt(j).ElementAt(i);
                indexCounter++;
            }
        }
        for (int i = 0; i < edgeAmount; i++)
        {
            GameObject edgeGo = Instantiate(edgeObject);
            edgeGo.GetComponent<LineManager>().ConnectLines(generatedVertices[i]);
        }
    }
    
    
    
}
