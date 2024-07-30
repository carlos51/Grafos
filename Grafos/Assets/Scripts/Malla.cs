using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Freya;
using Unity.VisualScripting;

public class Malla : MonoBehaviour
{
    public Nodos nodos;
    int n;
    private void Start()
    {
        n = nodos.cuerda.Length;
    }
}
