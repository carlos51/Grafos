using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuerda : MonoBehaviour
{
    GameObject[] nodes;  // Array de nodos de la cuerda
    private LineRenderer lineRenderer;
    Nodos nodos;
    // Start is called before the first frame update
    void Start()
    {
        nodos = GetComponent<Nodos>();
        if(nodos == null)
        {
            Debug.LogError("No se encontró el componente Nodos en el GameObject.");
            return;
        }
        nodes = nodos.cuerda;

        if (nodes == null || nodes.Length == 0)
        {
            Debug.LogError("El array de nodos no está asignado o está vacío.");
            return;
        }

        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            Debug.LogError("No se encontró el componente LineRenderer en el GameObject.");
            return;
        }

        lineRenderer.positionCount = nodes.Length;
    }

    // Update is called once per frame
    /*
    void Update()
    {
        for (int i = 0; i < nodes.Length; i++)
        {
            lineRenderer.SetPosition(i, nodes[i].transform.position);
        }
    }*/
}
