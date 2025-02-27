using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class CoratarCuerda : MonoBehaviour
{
    public Camera cam;

    // Cambiado a un array para manejar múltiples cuerdas
    public ObiRope[] ropes;
    LineRenderer lineRenderer;
    Vector3 cutStartPosition;
    Vector3 cutEndPosition;
    bool cut;

    private void Awake()
    {
        AddMouseLine();
    }

    private void OnDestroy()
    {
        DeleteMouseLine();
    }

    private void OnEnable()
    {
        // Suscribirse al evento para cada cuerda en el array
        foreach (var rope in ropes)
        {
            rope.OnSimulationStart += Rope_OnBeginSimulation;
        }
    }

    private void OnDisable()
    {
        // Desuscribirse del evento para cada cuerda en el array
        foreach (var rope in ropes)
        {
            rope.OnSimulationStart -= Rope_OnBeginSimulation;
        }
    }

    private void AddMouseLine()
    {
        GameObject line = new GameObject("Mouse Line");
        lineRenderer = line.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.005f;
        lineRenderer.endWidth = 0.005f;
        lineRenderer.numCapVertices = 2;
        lineRenderer.sharedMaterial = new Material(Shader.Find("Unlit/Color"));
        lineRenderer.sharedMaterial.color = Color.cyan;
        lineRenderer.enabled = false;
    }

    private void DeleteMouseLine()
    {
        if (lineRenderer != null)
            Destroy(lineRenderer.gameObject);
    }

    private void LateUpdate()
    {
        // No hacer nada si no tenemos una cámara para cortar.
        if (cam == null) return;

        // Procesar la entrada del usuario y cortar la cuerda si es necesario.
        ProcessInput();
    }

    private void Rope_OnBeginSimulation(ObiActor actor, float stepTime, float substepTime)
    {
        if (cut)
        {
            // Cortar todas las cuerdas
            foreach (var rope in ropes)
            {
                ScreenSpaceCut(rope, cutStartPosition, cutEndPosition);
            }

            cut = false;
        }
    }

    private void ProcessInput()
    {
        // Cuando el usuario hace clic, comenzar un corte de línea:
        // Verificar si hay al menos un toque en la pantalla
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                // Cuando el usuario toca la pantalla, empezar el corte de línea:
                case TouchPhase.Began:
                    cutStartPosition = touch.position;
                    lineRenderer.SetPosition(0, cam.ScreenToWorldPoint(new Vector3(cutStartPosition.x, cutStartPosition.y, 0.5f)));
                    lineRenderer.enabled = true;
                    break;

                // Mientras el usuario mueve el dedo, actualizar la línea:
                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    if (lineRenderer.enabled)
                        lineRenderer.SetPosition(1, cam.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0.5f)));
                    break;

                // Cuando el usuario suelta la pantalla, proceder a cortar:
                case TouchPhase.Ended:
                    cutEndPosition = touch.position;
                    lineRenderer.enabled = false;
                    cut = true;
                    break;
            }
        }
    }

    private void ScreenSpaceCut(ObiRope rope, Vector2 lineStart, Vector2 lineEnd)
    {
        bool ropeCut = false;

        for (int i = 0; i < rope.elements.Count; ++i)
        {
            Vector3 screenPos1 = cam.WorldToScreenPoint(rope.solver.positions[rope.elements[i].particle1]);
            Vector3 screenPos2 = cam.WorldToScreenPoint(rope.solver.positions[rope.elements[i].particle2]);

            if (SegmentSegmentIntersection(screenPos1, screenPos2, lineStart, lineEnd, out float r, out float s))
            {
                ropeCut = true;
                rope.Tear(rope.elements[i]);
            }
        }

        if (ropeCut) rope.RebuildConstraintsFromElements();
    }

    private bool SegmentSegmentIntersection(Vector2 A, Vector2 B, Vector2 C, Vector2 D, out float r, out float s)
    {
        float denom = (B.x - A.x) * (D.y - C.y) - (B.y - A.y) * (D.x - C.x);
        float rNum = (A.y - C.y) * (D.x - C.x) - (A.x - C.x) * (D.y - C.y);
        float sNum = (A.y - C.y) * (B.x - A.x) - (A.x - C.x) * (B.y - A.y);

        if (Mathf.Approximately(rNum, 0) || Mathf.Approximately(denom, 0))
        { r = -1; s = -1; return false; }

        r = rNum / denom;
        s = sNum / denom;

        return (r >= 0 && r <= 1 && s >= 0 && s <= 1);
    }
}
