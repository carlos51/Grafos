using System.Collections.Generic;
using UnityEngine;
using Obi;

public class ControladorNivel : MonoBehaviour
{
    public GameObject prefabCuerda;  // Prefab de la cuerda con ObiRope
    public List<GameObject> vertices; // Lista de los v�rtices (alfileres)
    public Grafo grafo;               // Grafo l�gico del nivel

    void Start()
    {
        grafo = new Grafo(vertices.Count); // Inicializamos el grafo con el n�mero de v�rtices
        CrearAristasIniciales(); // Creamos las cuerdas/aristas iniciales del nivel
    }

    void CrearAristasIniciales()
    {
        // Conectar cada par de v�rtices con una cuerda (arista) seg�n el nivel
        CrearArista(0, 1);
        CrearArista(1, 2);
        // A�ade aqu� m�s conexiones seg�n la configuraci�n de tu nivel
    }

    public void CrearArista(int v1, int v2)
    {
        GameObject nuevaCuerda = Instantiate(prefabCuerda);
        RopeDesanble ropeDesanble = nuevaCuerda.GetComponent<RopeDesanble>();

        // Configuramos la arista en el script RopeDesanble
        ropeDesanble.grafo = grafo;
        ropeDesanble.indiceArista = grafo.adyacencias[v1].Count;

        // A�adimos la arista al grafo
        grafo.AgregarArista(v1, v2);

        // Posicionar la cuerda f�sicamente entre los v�rtices
        ObiRope rope = nuevaCuerda.GetComponent<ObiRope>();
        Vector3 posicion1 = vertices[v1].transform.position;
        Vector3 posicion2 = vertices[v2].transform.position;

        // Aqu� configuramos los puntos de anclaje de la cuerda
        rope.GetComponent<ObiParticleAttachment>().target = vertices[v1].transform;
        rope.GetComponent<ObiParticleAttachment>().target = vertices[v2].transform;
    }

    public void VerificarHamiltoniano()
    {
        if (grafo.EsHamiltoniano())
        {
            Debug.Log("�Se ha formado un camino hamiltoniano!");
            // Aqu� puedes pasar al siguiente nivel
        }
    }
}
