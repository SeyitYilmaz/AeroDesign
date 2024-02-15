using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoadManager : MonoBehaviour
{
    public static DataLoadManager instance { get; private set; }
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        LoadVertexData();
    }
    public VertexList vertices = new VertexList();

    private void LoadVertexData()
    {
        var vertexDataJson = Resources.Load<TextAsset>("VertexData");
        vertices = JsonUtility.FromJson<VertexList>(vertexDataJson.text);
    }
}
