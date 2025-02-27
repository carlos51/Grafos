using UnityEngine;
using Obi;

public class CutRope : MonoBehaviour
{
    public ObiRope rope; // La cuerda que deseas cortar
    public float cutThreshold = 0.1f; // Distancia mínima para considerar un corte

    void Start()
    {
        Debug.Log(rope.blueprint.ToString());
    }


}
