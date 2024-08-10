using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Nodos : MonoBehaviour
{

    public GameObject first;
    public GameObject last;
    [Range(3,15)]
    public int nodos = 3;
    public GameObject[] cuerda;
    Vector3 initPos, finalPos;
    public float spring = 10;
    public float damper = 1;
    [Range (0.01f, 1f)]
    public float r, delta;
    public Vector3 direccion;
    // Start is called before the first frame update
    private void OnDrawGizmos()
    {
        direccion = last.transform.position - first.transform.position;
        delta = direccion.magnitude / nodos;
        direccion = direccion.normalized;
        Gizmos.DrawSphere(first.transform.position, r);
        Gizmos.DrawSphere(last.transform.position, r);
        first.transform.localScale = Vector3.one * r;
        last.transform.localScale = Vector3.one * r;

    }
    void Start()
    {
        cuerda = new GameObject[nodos];
        initPos = gameObject.transform.position;
        first.transform.position = initPos;
 

        cuerda[0] = first;
        cuerda[nodos-1] = last;

        
        for (int i = 1; i < nodos; i++)
        {
            Rigidbody rigidbody = cuerda[i - 1].GetComponent<Rigidbody>();
            GameObject current = Instantiate(first);
            current.name = i.ToString();
            current.transform.position = initPos + direccion * i * delta;
            current.transform.SetParent(gameObject.transform);
            ConfigurableJoint joint = current.AddComponent<ConfigurableJoint>();
            joint.connectedBody = rigidbody;
            //joint.autoConfigureConnectedAnchor = false;
            joint.xMotion = ConfigurableJointMotion.Locked;
            joint.yMotion = ConfigurableJointMotion.Locked;
            joint.zMotion = ConfigurableJointMotion.Locked;

            joint.anchor = Vector3.zero;  // Anclar en el centro del objeto
            joint.connectedAnchor = -direccion * delta;
            //joint.anchor = direccion * delta;
            //joint.spring = spring;
            //joint.maxDistance = 1;
            //joint.damper = damper;

            cuerda[i] = current;
        }
        cuerda[0].GetComponent<Rigidbody>().isKinematic = true;
        ConfigurableJoint joint2 = cuerda[nodos - 1].AddComponent<ConfigurableJoint>();
        joint2.connectedBody = cuerda[nodos-2].GetComponent<Rigidbody>();
        //joint2.autoConfigureConnectedAnchor = false;
        //joint2.spring = spring;
        //joint2.damper = damper;
        //cuerda[nodos-1].GetComponent<Rigidbody>().isKinematic = true;




    }
   
    
}
