using System.Collections.Generic; // Aseg�rate de que esto est� presente
using UnityEngine;
using Obi;

public class ControladorNivel : MonoBehaviour
{
    public GameObject prefabCuerda;  // Prefab de la cuerda con RopeDesanble
    public Grafo grafo;              // Referencia al grafo
    public List<GameObject> vertices; // V�rtices del nivel

    void Start()
    {
        grafo = new Grafo(vertices); // Inicializa el grafo con los v�rtices disponibles
    }

    // Crea una arista (cuerda) entre dos v�rtices
    public void CrearArista(int v1, int v2)
    {
        GameObject nuevaCuerda = Instantiate(prefabCuerda);
        RopeDesanble ropeDesanble = nuevaCuerda.GetComponent<RopeDesanble>();

        // Configurar la referencia al grafo y la arista
        ropeDesanble.grafo = grafo;
        ropeDesanble.indiceArista = grafo.aristas.Count;

        // Registrar la arista en el grafo
        grafo.AgregarArista(v1, v2);

        // Posicionar la cuerda entre los dos v�rtices
        ObiRope rope = nuevaCuerda.GetComponent<ObiRope>();
        rope.GetComponent<Transform>().position = vertices[v1].transform.position;
        // Aqu� se configura la conexi�n f�sica entre los dos v�rtices
    }
}
