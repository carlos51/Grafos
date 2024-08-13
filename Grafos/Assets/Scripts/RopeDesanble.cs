using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class RopeDesanble : MonoBehaviour
{
    ObiRope rope;
    int elementos;

    // Start is called before the first frame update
    void Start()
    {
        rope = GetComponent<ObiRope>();
        //elementos = rope.elements.Count;
    }

    // Update is called once per frame
    void Update()
    {
        elementos = elementos = rope.elements.Count;     
        Debug.Log("Numero de elemntos " + elementos.ToString());
    }
}
