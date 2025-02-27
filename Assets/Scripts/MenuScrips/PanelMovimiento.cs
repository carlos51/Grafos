using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMovimiento : MonoBehaviour
{

    [Range(1f, 20F)]
    public float ScrollSpeed = 1;
    public float ScrollOfSet;

    Vector2 StartPos;

    float NawPos;

    void Start()
    {
        StartPos = transform.position;
    }

    void Update()
    {
        NawPos = Mathf.Repeat(Time.time * - ScrollSpeed, ScrollOfSet);
        transform.position = StartPos + Vector2.right * NawPos;
    }
}
