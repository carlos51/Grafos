using System.Collections.Generic; // Asegúrate de que esto esté presente
using UnityEngine;
using Obi;

public class ControladorNivel : MonoBehaviour
{
    public GameObject prefabCuerda;  // Prefab de la cuerda con RopeDesanble
    public Grafo grafo;              // Referencia al grafo
    public List<GameObject> vertices; // Vértices del nivel

    void Start()
    {
        grafo = new Grafo(vertices); // Inicializa el grafo con los vértices disponibles
    }

    // Crea una arista (cuerda) entre dos vértices
    public void CrearArista(int v1, int v2)
    {
        GameObject nuevaCuerda = Instantiate(prefabCuerda);
        RopeDesanble ropeDesanble = nuevaCuerda.GetComponent<RopeDesanble>();

        // Configurar la referencia al grafo y la arista
        ropeDesanble.grafo = grafo;
        ropeDesanble.indiceArista = grafo.aristas.Count;

        // Registrar la arista en el grafo
        grafo.AgregarArista(v1, v2);

        // Posicionar la cuerda entre los dos vértices
        ObiRope rope = nuevaCuerda.GetComponent<ObiRope>();
        rope.GetComponent<Transform>().position = vertices[v1].transform.position;
        // Aquí se configura la conexión física entre los dos vértices
    }
}
