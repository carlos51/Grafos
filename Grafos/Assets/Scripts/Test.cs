using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Test : MonoBehaviour
{

    // Start is called before the first frame update
    [Range(3, 10)]
    public int resolucion = 3;
    [Range(2, 10)]
    public int largo = 2;
    Vector3[] baseBuff;
    Vector3[] vertices;
    //int[] triangles;
    float x, y, z;
    float angle;


    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnDrawGizmos()
    {
        Mesh mesh = new Mesh();
        baseBuff = new Vector3[resolucion];
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(gameObject.transform.position, .05f);

        angle = 2*Mathf.PI/resolucion;
        y = gameObject.transform.position.y;
        int[] triangles = new int[6*resolucion*largo];

        for (int i = 0; i < resolucion; i++)
        {
            x = Mathf.Cos(angle*i);
            z = Mathf.Sin(angle*i);
            baseBuff[resolucion] = new Vector3(x, y, z);

        }
        for (int i = 0; i < largo; i++)
        {
            for (int j = 0; j < resolucion; j++)
            {
                vertices[i*resolucion + j] = baseBuff[j] + Vector3.up*j;
            }
        }

        for (int i = 0; i < largo; i++)
        {
            for (int j = 0; j < resolucion; j++)
            {
                //Triangulo 1
                
            }
        }


        mesh.vertices = baseBuff;
        mesh.triangles = triangles;

        GetComponent<MeshFilter>().mesh = mesh;
        mesh.RecalculateNormals();
        Debug.Log("1");
    }
}
