using UnityEngine;

public class BezierCurve : MonoBehaviour
{
    public Vector3 p0, p1, p2, p3; // Puntos de control de la curva de Bézier

    public Vector3 GetPoint(float t)
    {
        return Mathf.Pow(1 - t, 3) * p0 +
               3 * Mathf.Pow(1 - t, 2) * t * p1 +
               3 * (1 - t) * Mathf.Pow(t, 2) * p2 +
               Mathf.Pow(t, 3) * p3;
    }
}
