using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Selfiedado
{
    public class SelfieDadoResult
    {
        public int idSelfiedado;
        public bool statusChange;
        public string resultadoFaceUp;
    }

    public class SelfieDadoMovement : MonoBehaviour
    {
        [SerializeField] int idSelfieDado;
        [SerializeField] float magnitudeForce = 10f;
        [SerializeField] AudioClip[] _hitNoice;
        [SerializeField] float _volume = 0.75f;

        private Rigidbody rbBody;
        private DetectFaceUp detectorCaras;
        private bool isOnGround = true;
        private bool isProcessed = false;
        private int _numberFx;

        private SelfieDadoResult selfiedadoInfo = new SelfieDadoResult();
        public SelfieDadoResult SelfiedadoInfo { get { return selfiedadoInfo; } }


        void Awake()
        {
            rbBody = GetComponent<Rigidbody>();
            detectorCaras = GetComponent<DetectFaceUp>();

            selfiedadoInfo.idSelfiedado = idSelfieDado;
            selfiedadoInfo.statusChange = isProcessed;

            _numberFx = _hitNoice.Length;

            if (Input.gyro.enabled)
            {
                Debug.Log("Gyro esta activo");
            }
            else
            {
                Input.gyro.enabled = true;
            }
        }

        void FixedUpdate()
        {
            /* * Version 2°*/

            if ((Input.gyro.userAcceleration.y > Mathf.Epsilon + 0.01f) && isOnGround)
            {
                //fuerza en centro de masa
                //rbBody.AddForce(mobileAcceleration * magnitudeForce);

                //fuerza fuera del centro de masa
                rbBody.AddForceAtPosition(Input.gyro.userAcceleration * magnitudeForce, transform.position + Vector3.right / 2 + Vector3.up / 2);

            }

            if ((rbBody.angularVelocity.magnitude <= Mathf.Epsilon) && isOnGround && !isProcessed)
            {
                isProcessed = true;
                selfiedadoInfo.resultadoFaceUp = detectorCaras.DeterminarCara();
                selfiedadoInfo.statusChange = isProcessed;
            }

            /*
             * Agregar fuerza horizontal para que se deslize en el tapete
             * 
            if ((Mathf.Abs(Input.gyro.userAcceleration.x) > 0.05f) || (Mathf.Abs(Input.gyro.userAcceleration.z) > 0.05f) && isOnGround)
            {
                Vector3 fuerzaHorizontal = new Vector3(Input.acceleration.z, 0, Input.acceleration.x);

                rbBody.AddForce(fuerzaHorizontal * magnitudeForce / 8);

            }
            */
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.gameObject.layer == 7)
            {
                isOnGround = true;
            }
            else
            {
                int selectSound = Random.Range(0, _numberFx);
                AudioSource.PlayClipAtPoint(_hitNoice[selectSound], Camera.main.transform.position, _volume);
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.collider.gameObject.layer == 7)
            {
                isOnGround = false;
                isProcessed = false;
                selfiedadoInfo.statusChange = isProcessed;
            }
        }

    }
}