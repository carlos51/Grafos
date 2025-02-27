using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cilindro : MonoBehaviour
{
    public int segments = 36; // Número de segmentos
    public float height = 2f; // Altura del cilindro
    public float radius = 1f; // Radio del cilindro
    // Start is called before the first frame update
    void Start()
    {
        MeshFilter mf = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        mf.mesh = mesh;

        Vector3[] vertices = new Vector3[2 * segments + 2]; // Vértices para los dos círculos + dos vértices centrales
        Vector3[] normals = new Vector3[vertices.Length];
        Vector2[] uvs = new Vector2[vertices.Length];
        int[] triangles = new int[12 * segments]; // 6 triángulos por segmento (2 por cara)

        float angleStep = 2 * Mathf.PI / segments;

        // Vértices para los círculos superior e inferior
        for (int i = 0; i < segments; i++)
        {
            float angle = i * angleStep;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;

            vertices[i] = new Vector3(x, 0, z); // Círculo inferior
            vertices[i + segments] = new Vector3(x, height, z); // Círculo superior
            normals[i] = Vector3.up;
            normals[i + segments] = Vector3.down;
            uvs[i] = new Vector2((float)i / segments, 0);
            uvs[i + segments] = new Vector2((float)i / segments, 1);
        }

        // Vértices centrales
        vertices[2 * segments] = new Vector3(0, 0, 0); // Centro inferior
        vertices[2 * segments + 1] = new Vector3(0, height, 0); // Centro superior
        normals[2 * segments] = Vector3.down;
        normals[2 * segments + 1] = Vector3.up;
        uvs[2 * segments] = new Vector2(0.5f, 0.5f);
        uvs[2 * segments + 1] = new Vector2(0.5f, 0.5f);

        // Triángulos para las caras laterales
        for (int i = 0; i < segments; i++)
        {
            int current = i;
            int next = (i + 1) % segments;

            // Triángulo 1
            triangles[6 * i] = current;
            triangles[6 * i + 1] = next + segments;
            triangles[6 * i + 2] = current + segments;

            // Triángulo 2
            triangles[6 * i + 3] = current;
            triangles[6 * i + 4] = next;
            triangles[6 * i + 5] = next + segments;
        }

        // Triángulos para las tapas
        for (int i = 0; i < segments; i++)
        {
            int current = i;
            int next = (i + 1) % segments;

            // Tapa inferior
            triangles[6 * segments + 3 * i] = 2 * segments;
            triangles[6 * segments + 3 * i + 1] = next;
            triangles[6 * segments + 3 * i + 2] = current;

            // Tapa superior
            triangles[9 * segments + 3 * i] = 2 * segments + 1;
            triangles[9 * segments + 3 * i + 1] = current + segments;
            triangles[9 * segments + 3 * i + 2] = next + segments;
        }

        mesh.vertices = vertices;
        mesh.normals = normals;
        mesh.uv = uvs;
        mesh.triangles = triangles;

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
