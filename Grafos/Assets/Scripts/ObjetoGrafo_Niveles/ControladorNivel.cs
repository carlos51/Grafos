using System.Collections.Generic;
using UnityEngine;
using Obi;

public class ControladorNivel : MonoBehaviour
{
    public GameObject prefabCuerda;  // Prefab de la cuerda con ObiRope
    public List<GameObject> vertices; // Lista de los vértices (alfileres)
    public Grafo grafo;               // Grafo lógico del nivel

    void Start()
    {
        grafo = new Grafo(vertices.Count); // Inicializamos el grafo con el número de vértices
        CrearAristasIniciales(); // Creamos las cuerdas/aristas iniciales del nivel
    }

    void CrearAristasIniciales()
    {
        // Conectar cada par de vértices con una cuerda (arista) según el nivel
        CrearArista(7, 5);
        CrearArista(1, 7);
        CrearArista(0, 5);
        CrearArista(0, 1);
        CrearArista(0, 2);
        CrearArista(2, 6);
        CrearArista(5, 6);
        CrearArista(2, 3);
        CrearArista(3, 4);
        CrearArista(4, 6);
        CrearArista(3, 1);
        CrearArista(4, 7);
        // Añade aquí más conexiones según la configuración de tu nivel
    }

    public void CrearArista(int v1, int v2)
    {
        GameObject nuevaCuerda = Instantiate(prefabCuerda);
        RopeDesanble ropeDesanble = nuevaCuerda.GetComponent<RopeDesanble>();

        // Configuramos la arista en el script RopeDesanble
        ropeDesanble.grafo = grafo;
        ropeDesanble.indiceArista = grafo.adyacencias[v1].Count;

        // Añadimos la arista al grafo
        grafo.AgregarArista(v1, v2);

        // Posicionar la cuerda físicamente entre los vértices
        ObiRope rope = nuevaCuerda.GetComponent<ObiRope>();
        Vector3 posicion1 = vertices[v1].transform.position;
        Vector3 posicion2 = vertices[v2].transform.position;

        // Aquí configuramos los puntos de anclaje de la cuerda
        rope.GetComponent<ObiParticleAttachment>().target = vertices[v1].transform;
        rope.GetComponent<ObiParticleAttachment>().target = vertices[v2].transform;
    }

    public void VerificarHamiltoniano()
    {
        if (grafo.EsHamiltoniano())
        {
            Debug.Log("¡Se ha formado un camino hamiltoniano!");
            // Aquí puedes pasar al siguiente nivel
        }
    }
}
