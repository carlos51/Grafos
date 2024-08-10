﻿using UnityEngine;
using System.Collections;

namespace Obi
{
    public struct ColliderRigidbody
    {
        public Matrix4x4 inverseInertiaTensor;
        public Vector4 velocity;
        public Vector4 angularVelocity;
        public Vector4 com;
        public float inverseMass;
         
        public int constraintCount;
        private int pad1;
        private int pad2;

        public void FromRigidbody(ObiRigidbody rb)
        {
            bool kinematic = !Application.isPlaying || rb.unityRigidbody.isKinematic || rb.kinematicForParticles;

            //rotation = source.rotation;
            velocity = rb.kinematicForParticles ? Vector3.zero : rb.linearVelocity;
            angularVelocity = rb.kinematicForParticles ? Vector3.zero : rb.angularVelocity;

            // center of mass in unity is affected by local rotation and position, but not scale. We need it expressed in world space:
            com = rb.unityRigidbody.position + rb.unityRigidbody.rotation * rb.unityRigidbody.centerOfMass;

            Vector3 invTensor = new Vector3((rb.unityRigidbody.constraints & RigidbodyConstraints.FreezeRotationX) != 0 ? 0 : 1 / rb.unityRigidbody.inertiaTensor.x,
                                            (rb.unityRigidbody.constraints & RigidbodyConstraints.FreezeRotationY) != 0 ? 0 : 1 / rb.unityRigidbody.inertiaTensor.y,
                                            (rb.unityRigidbody.constraints & RigidbodyConstraints.FreezeRotationZ) != 0 ? 0 : 1 / rb.unityRigidbody.inertiaTensor.z);

            // the inertia tensor is a diagonal matrix (Vector3) because it is expressed in the space generated by the principal axes of rotation (inertiaTensorRotation).
            Vector3 inertiaTensor = kinematic ? Vector3.zero : invTensor;

            // calculate full world space inertia matrix:
            Matrix4x4 rotation = Matrix4x4.Rotate(rb.unityRigidbody.rotation * rb.unityRigidbody.inertiaTensorRotation);
            inverseInertiaTensor = rotation * Matrix4x4.Scale(inertiaTensor) * rotation.transpose;

            inverseMass = kinematic ? 0 : 1 / rb.unityRigidbody.mass;

        }

        public void FromRigidbody(ObiRigidbody2D rb)
        {

            bool kinematic = !Application.isPlaying || rb.unityRigidbody.isKinematic || rb.kinematicForParticles;
            velocity = rb.linearVelocity;

            // For some weird reason, in 2D angular velocity is measured in *degrees* per second, 
            // instead of radians. Seriously Unity, WTF??
            angularVelocity = new Vector4(0, 0, rb.angularVelocity * Mathf.Deg2Rad, 0);

            // center of mass in unity is affected by local rotation and poistion, but not scale. We need it expressed in world space:
            com = rb.transform.position + rb.transform.rotation * rb.unityRigidbody.centerOfMass;

            Vector3 inertiaTensor = kinematic ? Vector3.zero : new Vector3(0, 0, (rb.unityRigidbody.constraints & RigidbodyConstraints2D.FreezeRotation) != 0 ? 0 : 1 / rb.unityRigidbody.inertia);

            Matrix4x4 rotation = Matrix4x4.Rotate(Quaternion.AngleAxis(rb.rotation, Vector3.forward));
            inverseInertiaTensor = rotation * Matrix4x4.Scale(inertiaTensor) * rotation.transpose;

            inverseMass = kinematic ? 0 : 1 / rb.unityRigidbody.mass;

        }


    }
}
