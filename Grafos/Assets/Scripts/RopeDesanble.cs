using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class RopeDesanble : MonoBehaviour
{
    public ObiRope rope;     // Referencia a la cuerda física
    public Grafo grafo;       // Referencia al grafo lógico
    public int indiceArista;  // Índice de la arista en el grafo

    private int elementos;    // Número de segmentos actuales de la cuerda

    void Start()
    {
        if (rope == null)
        {
            rope = GetComponent<ObiRope>();
        }

        elementos = rope.elements.Count;
    }

    void Update()
    {
        int elementosActuales = rope.elements.Count;

        if (elementosActuales != elementos) // Detecta cambios en los segmentos
        {
            elementos = elementosActuales;

            if (elementos == 0) // Si la cuerda fue completamente cortada
            {
                grafo.EliminarArista(indiceArista); // Eliminar la arista del grafo
                Destroy(gameObject); // Destruir la representación física de la cuerda
            }
        }
    }
}

