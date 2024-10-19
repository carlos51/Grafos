using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class RopeDesanble : MonoBehaviour
{
    public ObiRope rope;      // Referencia a la cuerda f�sica.
    public Grafo grafo;        // Referencia al grafo l�gico.
    public int indiceArista;   // �ndice de la arista en el grafo.

    private int segmentos;     // N�mero inicial de segmentos de la cuerda.

    void Start()
    {
        if (rope == null)
        {
            rope = GetComponent<ObiRope>();  // Asegura la referencia a ObiRope.
        }

        segmentos = rope.elements.Count;  // Guarda el n�mero inicial de segmentos.
    }

    void Update()
    {
        int segmentosActuales = rope.elements.Count;

        // Si el n�mero de segmentos cambia, significa que la cuerda fue cortada.
        if (segmentosActuales != segmentos)
        {
            segmentos = segmentosActuales;

            if (segmentos == 0)  // Si la cuerda ha sido completamente cortada.
            {
                grafo.EliminarArista(indiceArista);  // Actualiza el grafo.
                Destroy(gameObject);  // Destruye la cuerda f�sica.
            }
        }
    }
}

