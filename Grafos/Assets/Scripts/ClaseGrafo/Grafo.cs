using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Grafo
{
    public List<Vertice> Vertices { get; private set; }
    public List<Arista> Aristas { get; private set; }

    // Constructor
    public Grafo()
    {
        Vertices = new List<Vertice>();
        Aristas = new List<Arista>();
    }

    // Definir los vértices y aristas para el nivel actual
    public void ConfigurarGrafo(List<string> nombresVertices, List<(string, string)> conexiones)
    {
        // Crear vértices a partir de la lista de nombres
        foreach (string nombre in nombresVertices)
        {
            AgregarVertice(new Vertice(nombre));
        }

        // Crear aristas a partir de las conexiones especificadas
        foreach (var (v1, v2) in conexiones)
        {
            Vertice vertice1 = ObtenerVerticePorNombre(v1);
            Vertice vertice2 = ObtenerVerticePorNombre(v2);

            if (vertice1 != null && vertice2 != null)
            {
                AgregarArista(vertice1, vertice2);
            }
            else
            {
                Debug.LogError($"No se encontró uno de los vértices: {v1} o {v2}");
            }
        }
    }

    private Vertice ObtenerVerticePorNombre(string nombre)
    {
        return Vertices.Find(v => v.Nombre == nombre);
    }

    public void AgregarVertice(Vertice v)
    {
        Vertices.Add(v);
    }

    public void AgregarArista(Vertice v1, Vertice v2)
    {
        Arista nuevaArista = new Arista(v1, v2);
        Aristas.Add(nuevaArista);
        v1.Aristas.Add(nuevaArista);
        v2.Aristas.Add(nuevaArista);
    }

    public void RemoverArista(Arista arista)
    {
        Aristas.Remove(arista);
        arista.V1.Aristas.Remove(arista);
        arista.V2.Aristas.Remove(arista);
    }
}
