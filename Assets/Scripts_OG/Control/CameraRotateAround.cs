using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Control
{
    public class CameraRotateAround : MonoBehaviour
    {
        public Transform objectToOrbit;
        public float radius;

        void Update()
        {
            transform.position = objectToOrbit.position - (transform.forward * radius);
            transform.RotateAround(objectToOrbit.position, Vector3.up, Input.GetAxis("Mouse X"));
            transform.RotateAround(objectToOrbit.position, transform.right, Input.GetAxis("Mouse Y"));
        }
    }
}
