using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Test : MonoBehaviour
{

    // Start is called before the first frame update
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;
    // Update is called once per frame
    private void OnDrawGizmos()
    {
        mesh = gameObject.GetComponent<MeshFilter>().mesh;
        mesh.vertices = new Vector3[] {
            Vector3.zero,
            Vector3.up,
            new Vector3 (1, 1, 0),
            Vector3.right
        };

        triangles = new int[] {
            0, 1, 2, 2, 3 ,0
        };

        mesh.triangles = triangles;
    }
}
