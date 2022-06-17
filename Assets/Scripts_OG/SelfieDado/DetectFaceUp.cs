using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Selfiedado
{
    public class DetectFaceUp : MonoBehaviour
    {
        [SerializeField] CarasDados[] listaCaras;

        public string DeterminarCara()
        {
            //caso x
            if (Vector3.Cross(transform.right, Vector3.up).magnitude <= 0.1f)
            {

                if (Vector3.Dot(transform.right, Vector3.up) >= 0)
                {
                    return listaCaras[0].caraArriba;
                }
                else
                {
                    return listaCaras[0].caraAbajo;
                }
            }

            //caso eje z
            else if (Vector3.Cross(transform.forward, Vector3.up).magnitude <= 0.1f)
            {

                if (Vector3.Dot(transform.forward, Vector3.up) >= 0)
                {
                    return listaCaras[1].caraArriba;
                }
                else
                {
                    return listaCaras[1].caraAbajo;
                }
            }

            //caso eje y
            else if (Vector3.Cross(transform.up, Vector3.up).magnitude <= 0.1f)
            {

                if (Vector3.Dot(transform.up, Vector3.up) >= 0)
                {
                    return listaCaras[2].caraArriba;
                }
                else
                {
                    return listaCaras[2].caraAbajo;
                }
            }

            return null;
        }
    }


    [System.Serializable]
    public class CarasDados
    {
        public string nombreEje;
        public string caraArriba;
        public string caraAbajo;

        /*
         * public delegate Vector3 EjeReferencia();

         private Vector3 ejeLocalReferencia;
         public Vector3 EjeLocalReferencia 
         {  
             get { return ejeLocalReferencia; } 
             set { ejeLocalReferencia = value; } 
         }
        */
    }
}

//**************************
//
//Esta solucion NO funciona porque Vector3 no es referencia, se copian los valores iniciales y no van cambiando
//Commented solution does not work, but leaving the code to study it (reference problem)

//**************************

//private Dictionary<int, CarasDados> mapaDado = new Dictionary<int, CarasDados>();
//bool isProcessing = false;

/*
void Start()
{
    //CrearMapeoDado();
}

private void Update()
{
    if(transform.hasChanged)
    {
        //string resultado = DeterminarCara();
        Debug.Log("se cambio algo");
        transform.hasChanged = false;
    }
}

private void CrearMapeoDado()
{
    Vector3[] nombreEjes = {transform.right, transform.forward, transform.up};
    int size = nombreEjes.Length;

    for(int indice = 0; indice < size; indice++)
    {
        listaCaras[indice].EjeLocalReferencia = nombreEjes[indice];
        mapaDado.Add(indice, listaCaras[indice]);
        Debug.Log($"la caras son {listaCaras[indice].caraArriba} + {listaCaras[indice].caraAbajo} y" +
            $"nombre del vector es {listaCaras[indice].EjeLocalReferencia}");
    }
}

public string DeterminarCara()
{
    int indiceDicc = mapaDado.Count;

    for (int indice = 0; indice < indiceDicc; indice++)
    {
        Debug.Log($"Magnitud producto cruz es {Vector3.Cross(mapaDado[indice].EjeLocalReferencia, Vector3.up).magnitude}");
        if (Vector3.Cross(mapaDado[indice].EjeLocalReferencia, Vector3.up).magnitude <= Mathf.Epsilon)
        {
            Debug.Log($"el prodcuto cruz es {mapaDado[indice].caraArriba} + {mapaDado[indice].caraAbajo} y" +
$"nombre del vector es {mapaDado[indice].EjeLocalReferencia} y vector.up es: {Vector3.up}");

            if (Vector3.Dot(mapaDado[indice].EjeLocalReferencia, Vector3.up) >= 0)
            {
                //Debug.Log("este es el resultado: " + mapaDado[indice].caraArriba);
                return mapaDado[indice].caraArriba;

            }
            else
            {
                //Debug.Log("este es el resultado: " + mapaDado[indice].caraAbajo);
                return mapaDado[indice].caraAbajo;
            }
        }
    }
    return null;
} */