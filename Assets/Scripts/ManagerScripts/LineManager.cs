using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public VertexList vertices;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void ConnectLines(VertexList vertices)
    {
        lineRenderer.positionCount = vertices.Vertices.Length;
        this.vertices = vertices;
        StartCoroutine(WaitForEndOfFrame());
    }

    /*private void Start()
    {
        for (int i = 0; i < vertices.Vertices.Length; i++)
        {
            lineRenderer.SetPosition(i, new Vector3(vertices.Vertices[i].x, vertices.Vertices[i].y, 0));
        }
    }*/
    private IEnumerator WaitForEndOfFrame()
    {
        yield return new WaitForEndOfFrame();
        for (int i = 0; i < vertices.Vertices.Length; i++)
        {
            lineRenderer.SetPosition(i, new Vector3(vertices.Vertices[i].x, vertices.Vertices[i].y, 0));
        }
    }
}
