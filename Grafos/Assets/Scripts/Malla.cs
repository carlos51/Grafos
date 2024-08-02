using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Freya;
using Unity.VisualScripting;
using System.Buffers.Text;

public class Malla : MonoBehaviour
{
    //public GameObject cuerda;
    private Nodos nodos;
    [Range(3, 50)]
    public int n = 2;
    private Vector3 direccion;
    private Vector3 u, v, w;
    public Vector3 test;
    private Matrix4x4 matrix, invMatrix;
    private Vector3[] vector3s;
    private float delta;
    private Mesh mesh;
    private int[] triangle;

    private void OnDrawGizmos()
    {
        InitializeVariables();
        CalculateOrthogonalVectors();
        SetTransformationMatrices();
        DrawGizmos();
        GenerateMesh();
    }

    private void InitializeVariables()
    {
        nodos = gameObject.GetComponent<Nodos>();
        matrix = new Matrix4x4();
        vector3s = new Vector3[n * nodos.nodos];
        delta = (2 * Mathf.PI) / n;
        u = nodos.direccion;
        mesh = gameObject.GetComponent<MeshFilter>().sharedMesh;
        triangle = new int[n * nodos.nodos * 6];
       
    }



    private void DrawGizmos()
    {
        Vector3 baseC = gameObject.transform.position;
        
        Gizmos.color = Color.red;
        Gizmos.DrawLine(baseC, baseC + u);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(baseC, baseC + v);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(baseC, baseC + w);
        Gizmos.color = Color.black;
        
        for (int j = 0; j < nodos.nodos; j++)
        {
            Vector3 dezplazamiento = u * nodos.delta * j;
            //Debug.Log(nodos.cuerda.Length);
            //Vector3 dezplazamiento = nodos.cuerda[j].transform.position;
            for (int i = 0; i < n; i++)
            {
                Vector3 current = matrix.MultiplyVector(w * nodos.r + dezplazamiento);
                current = MultMat(current, i * delta);
                current = invMatrix.MultiplyVector(current);
                vector3s[i + j * n] = current;
            }
        }
    }

    private void GenerateMesh()
    {
        for (int j = 1; j < nodos.nodos; j++)
        {
            for (int i = 0; i < n; i++)
            {
                int a = i + (j - 1) * n;
                int b = (i + n * j);
                int c = ((i + 1) % n + n * j);
                int d = ((i + 1) % n + n * (j - 1));

                triangle[i * 6 + (j - 1) * n * 6] = a;
                triangle[i * 6 + (j - 1) * n * 6 + 1] = b;
                triangle[i * 6 + (j - 1) * n * 6 + 2] = c;
                triangle[i * 6 + (j - 1) * n * 6 + 3] = c;
                triangle[i * 6 + (j - 1) * n * 6 + 4] = d;
                triangle[i * 6 + (j - 1) * n * 6 + 5] = a;
            }
        }

        mesh.vertices = vector3s;
        mesh.triangles = triangle;
        mesh.RecalculateNormals();
    }

    private Vector3 MultMat(Vector3 vector, float angle)
    {
        Matrix4x4 rotX = new Matrix4x4();
        rotX.SetRow(0, new Vector4(1, 0, 0, 0));
        rotX.SetRow(1, new Vector4(0, Mathf.Cos(angle), -Mathf.Sin(angle), 0));
        rotX.SetRow(2, new Vector4(0, Mathf.Sin(angle), Mathf.Cos(angle), 0));
        rotX.SetRow(3, new Vector4(0, 0, 0, 1));

        return rotX.MultiplyVector(vector);
    }
    private void CalculateOrthogonalVectors()
    {
        if (u != Vector3.forward && u != Vector3.back)
        {
            v = Vector3.Cross(u, Vector3.forward).normalized;
        }
        else
        {
            v = Vector3.Cross(u, Vector3.up).normalized;
        }

        w = Vector3.Cross(u, v).normalized;
    }
    private void SetTransformationMatrices()
    {
        matrix.SetRow(0, new Vector4(u.x, u.y, u.z, 0));
        matrix.SetRow(1, new Vector4(w.x, w.y, w.z, 0));
        matrix.SetRow(2, new Vector4(v.x, v.y, v.z, 0));
        matrix.SetRow(3, new Vector4(0, 0, 0, 1));

        invMatrix = matrix.inverse;
    }

}
