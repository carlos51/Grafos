using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class RopeDesanble : MonoBehaviour
{
    public ObiRope rope;      // Referencia a la cuerda física.
    public Grafo grafo;        // Referencia al grafo lógico.
    public int indiceArista;   // Índice de la arista en el grafo.

    private int segmentos;     // Número inicial de segmentos de la cuerda.

    void Start()
    {
        if (rope == null)
        {
            rope = GetComponent<ObiRope>();  // Asegura la referencia a ObiRope.
        }

        segmentos = rope.elements.Count;  // Guarda el número inicial de segmentos.
    }

    void Update()
    {
        int segmentosActuales = rope.elements.Count;

        // Si el número de segmentos cambia, significa que la cuerda fue cortada.
        if (segmentosActuales != segmentos)
        {
            segmentos = segmentosActuales;

            if (segmentos == 0)  // Si la cuerda ha sido completamente cortada.
            {
                grafo.EliminarArista(indiceArista);  // Actualiza el grafo.
                Destroy(gameObject);  // Destruye la cuerda física.
            }
        }
    }
}

