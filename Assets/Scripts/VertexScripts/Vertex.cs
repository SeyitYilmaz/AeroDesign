using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[System.Serializable]
public class Vertex
{
    public float x;
    public float y;
    public float z;
    
    public static Vertex[] CreateEnlargedVertices(Vertex[] vertices, int multiplierValue)
    {
        Vertex[] Vertices = vertices.Select(v=> new Vertex { x = v.x * multiplierValue,
            y = v.y * multiplierValue, z = v.z * multiplierValue}).ToArray();
        return Vertices;
    }

    public static Vertex[] CreateVerticeInstance(Vertex[] vertices, float zValue)
    {
        Vertex[] Vertices = vertices.Select(v=> new Vertex { x = v.x,
            y = v.y, z = zValue }).ToArray();
        
        return Vertices;
    }
}
