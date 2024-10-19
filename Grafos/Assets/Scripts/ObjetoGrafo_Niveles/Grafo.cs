using System.Collections.Generic;
using UnityEngine;

public class Grafo
{
    public List<GameObject> vertices;  // V�rtices del grafo (alfileres).
    public List<(int, int)> aristas;   // Aristas (cuerdas) como pares de �ndices.

    public Grafo(List<GameObject> vertices)
    {
        this.vertices = vertices;
        aristas = new List<(int, int)>();
    }

    // Agrega una arista (cuerda) entre dos v�rtices.
    public void AgregarArista(int v1, int v2)
    {
        aristas.Add((v1, v2));
        Debug.Log($"Arista agregada entre {v1} y {v2}");
    }

    // Elimina una arista del grafo.
    public void EliminarArista(int indice)
    {
        if (indice >= 0 && indice < aristas.Count)
        {
            var arista = aristas[indice];
            aristas.RemoveAt(indice);
            Debug.Log($"Arista eliminada entre {arista.Item1} y {arista.Item2}");
        }
    }

    // Verifica si se ha formado un camino hamiltoniano.
    public bool CaminoHamiltoniano()
    {
        // L�gica de detecci�n de camino hamiltoniano (simplificada por ahora).
        return aristas.Count == vertices.Count - 1;
    }
}
