using System.Collections.Generic;
using UnityEngine;

public class Grafo
{
    public List<GameObject> vertices;  // V�rtices del grafo
    public List<(int, int)> aristas;   // Aristas como pares de �ndices de v�rtices

    public Grafo(List<GameObject> verts)
    {
        vertices = verts;
        aristas = new List<(int, int)>();
    }

    // Agrega una arista entre dos v�rtices
    public void AgregarArista(int v1, int v2)
    {
        aristas.Add((v1, v2));
    }

    // Elimina la arista especificada por su �ndice
    public void EliminarArista(int indice)
    {
        if (indice >= 0 && indice < aristas.Count)
        {
            aristas.RemoveAt(indice);
            Debug.Log($"Arista {indice} eliminada del grafo.");
        }
    }
}

