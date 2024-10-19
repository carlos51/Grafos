using System.Collections.Generic;
using UnityEngine;
using Obi;

public class ControladorNivel : MonoBehaviour
{
    public GameObject prefabCuerda;  // Prefab de la cuerda con RopeDesanble.
    public List<GameObject> vertices; // Vértices del nivel.
    public Grafo grafo;  // Grafo lógico del nivel.

    void Start()
    {
        // Inicializa el grafo con los vértices.
        grafo = new Grafo(vertices);

        // Crear las aristas (cuerdas) entre los vértices.
        CrearArista(0, 1);
        CrearArista(1, 2);
        CrearArista(2, 3);
        CrearArista(3, 0);
    }

    // Crea una cuerda física y la conecta a dos vértices.
    public void CrearArista(int v1, int v2)
    {
        GameObject nuevaCuerda = Instantiate(prefabCuerda);
        RopeDesanble ropeDesanble = nuevaCuerda.GetComponent<RopeDesanble>();

        // Configurar la referencia al grafo y la arista.
        ropeDesanble.grafo = grafo;
        ropeDesanble.indiceArista = grafo.aristas.Count;

        // Registrar la arista en el grafo.
        grafo.AgregarArista(v1, v2);

        // Posicionar la cuerda entre los dos vértices.
        ObiRope rope = nuevaCuerda.GetComponent<ObiRope>();
        rope.GetComponent<Transform>().position = vertices[v1].transform.position;
        // Aquí puedes añadir lógica para anclar la cuerda a los vértices.
    }

    void Update()
    {
        // Verificar si se ha completado el nivel.
        if (grafo.CaminoHamiltoniano())
        {
            Debug.Log("¡Nivel completado!");
            // Aquí puedes avanzar al siguiente nivel o mostrar un mensaje de victoria.
        }
    }
}
