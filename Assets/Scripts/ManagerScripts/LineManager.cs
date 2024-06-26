using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public Vertex[] vertices;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void ConnectLines(Vertex[] vertices)
    {
        lineRenderer.positionCount = vertices.Length;
        this.vertices = vertices;
        StartCoroutine(WaitForEndOfFrame());
    }
    
    
    private IEnumerator WaitForEndOfFrame()
    {
        yield return new WaitForEndOfFrame();
        for (int i = 0; i < vertices.Length; i++)
        {
            lineRenderer.SetPosition(i, new Vector3(vertices[i].x, vertices[i].y, vertices[i].z));
        }
    }
}
