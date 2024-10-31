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
                // Eliminar la arista del grafo
                grafo.EliminarArista(indiceArista, indiceArista + 1); // Ajusta según tu lógica
                Destroy(gameObject); // Destruir la cuerda física

                // Verificar si se ha formado un camino hamiltoniano
                FindObjectOfType<ControladorNivel>().VerificarHamiltoniano();
            }
        }
    }
}

