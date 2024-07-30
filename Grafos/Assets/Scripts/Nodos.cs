using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Nodos : MonoBehaviour
{

    public GameObject first;
    public GameObject last;
    public int nodos = 3;
    public GameObject[] cuerda;
    Vector3 initPos, finalPos;
    public float spring = 10;
    public float damper = 1;
    float r, delta;
    Vector3 direccion;
    // Start is called before the first frame update
    void Start()
    {
        cuerda = new GameObject[nodos];
        initPos = gameObject.transform.position;
        first.transform.position = initPos;
        direccion = last.transform.position - first.transform.position;
        delta = direccion.magnitude/nodos;
        direccion = direccion.normalized;

        cuerda[0] = first;
        cuerda[nodos-1] = last;

        
        for (int i = 1; i < nodos-1; i++)
        {
            Rigidbody rigidbody = cuerda[i - 1].GetComponent<Rigidbody>();
            GameObject current = Instantiate(first);
            current.name = i.ToString();
            current.transform.position = initPos + direccion * i * delta;
            current.transform.SetParent(gameObject.transform);
            SpringJoint joint = current.AddComponent<SpringJoint>();
            joint.connectedBody = rigidbody;
            joint.autoConfigureConnectedAnchor = false;
            joint.spring = spring;
            //joint.maxDistance = 1;
            joint.damper = damper;

            cuerda[i] = current;
        }
        cuerda[0].GetComponent<Rigidbody>().isKinematic = true;
        SpringJoint joint2 = cuerda[nodos - 1].AddComponent<SpringJoint>();
        joint2.connectedBody = cuerda[nodos-2].GetComponent<Rigidbody>();
        joint2.autoConfigureConnectedAnchor = false;
        joint2.spring = spring;
        joint2.damper = damper;
        //cuerda[nodos-1].GetComponent<Rigidbody>().isKinematic = true;


    }
   
}
