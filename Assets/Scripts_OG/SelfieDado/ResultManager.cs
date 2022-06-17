using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Game.Selfiedado
{
    public class ResultManager : MonoBehaviour
    {
        [SerializeField] List<SelfieDadoMovement> listaSelfieDados;
        [SerializeField] TextMeshProUGUI canvasResultDice;
        [SerializeField] Image backgroundColor;

        List<SelfieDadoResult> estadoDeSelfieDados = new List<SelfieDadoResult>();

        private const string RESULTADO_HEADER = "Desafío: ";
        private const string ESPACIO = " + ";
        private bool isResultsRead = false;

        void Start()
        {
            ToogleResultBanner(false);
            InitSelfiedados();
        }

        void FixedUpdate()
        {
            if (DeterminarDadosDetenidos())
            {
                if (isResultsRead == false)
                {
                    SetearResultadosCanvas();
                }
            }
            else
            {
                ToogleResultBanner(false);
            }
        }

        private void InitSelfiedados()
        {
            foreach (SelfieDadoMovement selfiedado in listaSelfieDados)
            {
                estadoDeSelfieDados.Add(selfiedado.SelfiedadoInfo);
            }
        }

        private bool DeterminarDadosDetenidos()
        {
            int lenghtList = estadoDeSelfieDados.Count;

            for (int index = 0; index < lenghtList; index++)
            {
                if (estadoDeSelfieDados[index].statusChange == false)
                {
                    return false;
                }
            }

            return true;
        }

        private void SetearResultadosCanvas()
        {

            int lenghtList = estadoDeSelfieDados.Count;
            string respuestaCompleta = RESULTADO_HEADER;

            for (int index = 1; index <= lenghtList; index++)
            {
                SelfieDadoResult resultadoOrden = estadoDeSelfieDados.Find(x => x.idSelfiedado == index);
                respuestaCompleta += resultadoOrden.resultadoFaceUp + ESPACIO;
            }

            ToogleResultBanner(true);
            canvasResultDice.SetText(respuestaCompleta.Substring(0, respuestaCompleta.Length - 3));
        }

        private void ToogleResultBanner(bool state)
        {
            canvasResultDice.enabled = state;
            backgroundColor.enabled = state;
            isResultsRead = state;
        }

    }
}