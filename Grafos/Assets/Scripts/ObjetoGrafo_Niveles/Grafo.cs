using System.Collections.Generic;

public class Grafo
{
    public List<int>[] adyacencias;  // Lista de adyacencia para representar el grafo
    public int numVertices;

    public Grafo(int numVertices)
    {
        this.numVertices = numVertices;
        adyacencias = new List<int>[numVertices];
        for (int i = 0; i < numVertices; i++)
        {
            adyacencias[i] = new List<int>();
        }
    }

    public void AgregarArista(int v1, int v2)
    {
        adyacencias[v1].Add(v2);
        adyacencias[v2].Add(v1);
    }

    public void EliminarArista(int v1, int v2)
    {
        adyacencias[v1].Remove(v2);
        adyacencias[v2].Remove(v1);
    }

    // Verifica si se ha formado un camino o ciclo hamiltoniano
    public bool EsHamiltoniano()
    {
        bool[] visitados = new bool[numVertices];
        return HamiltonianoRecursivo(0, visitados, 1);
    }

    private bool HamiltonianoRecursivo(int actual, bool[] visitados, int visitadosCount)
    {
        visitados[actual] = true;

        // Si hemos visitado todos los vértices una vez, es hamiltoniano
        if (visitadosCount == numVertices) return true;

        // Explorar vecinos
        foreach (var vecino in adyacencias[actual])
        {
            if (!visitados[vecino])
            {
                if (HamiltonianoRecursivo(vecino, visitados, visitadosCount + 1))
                    return true;
            }
        }

        // Backtracking
        visitados[actual] = false;
        return false;
    }
}

