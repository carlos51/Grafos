using System.Collections.Generic;
using UnityEngine;

public class Grafo
{
    public List<GameObject> vertices;  // Vértices del grafo
    public List<(int, int)> aristas;   // Aristas como pares de índices de vértices

    public Grafo(List<GameObject> verts)
    {
        vertices = verts;
        aristas = new List<(int, int)>();
    }

    // Agrega una arista entre dos vértices
    public void AgregarArista(int v1, int v2)
    {
        aristas.Add((v1, v2));
    }

    // Elimina la arista especificada por su índice
    public void EliminarArista(int indice)
    {
        if (indice >= 0 && indice < aristas.Count)
        {
            aristas.RemoveAt(indice);
            Debug.Log($"Arista {indice} eliminada del grafo.");
        }
    }
}

