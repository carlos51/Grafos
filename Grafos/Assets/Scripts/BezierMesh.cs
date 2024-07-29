using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class BezierMesh : MonoBehaviour
{
    public BezierCurve bezierCurve;
    public int segmentCount = 20; // Número de segmentos de la curva
    public float radius = 0.5f; // Radio de la malla alrededor de la curva
    public int circleSegmentCount = 8; // Número de segmentos del círculo

    void Start()
    {
        GenerateMesh();
    }

    void GenerateMesh()
    {
        MeshFilter mf = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        mf.mesh = mesh;

        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();

        float angleStep = 360f / circleSegmentCount;
        for (int i = 0; i <= segmentCount; i++)
        {
            float t = i / (float)segmentCount;
            Vector3 center = bezierCurve.GetPoint(t);

            for (int j = 0; j < circleSegmentCount; j++)
            {
                float angle = j * angleStep * Mathf.Deg2Rad;
                Vector3 offset = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
                vertices.Add(center + offset);
            }

            if (i < segmentCount)
            {
                int baseIndex = i * circleSegmentCount;
                for (int j = 0; j < circleSegmentCount; j++)
                {
                    int nextJ = (j + 1) % circleSegmentCount;
                    triangles.Add(baseIndex + j);
                    triangles.Add(baseIndex + nextJ);
                    triangles.Add(baseIndex + j + circleSegmentCount);

                    triangles.Add(baseIndex + nextJ);
                    triangles.Add(baseIndex + nextJ + circleSegmentCount);
                    triangles.Add(baseIndex + j + circleSegmentCount);
                }
            }
        }

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
    }
}
