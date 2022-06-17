using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

namespace Game.Control
{
    public class OpenLinks : MonoBehaviour, IPointerClickHandler
    {
        TextMeshProUGUI _text;

        void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {

            int indiceLink = TMP_TextUtilities.FindIntersectingLink(_text, Input.mousePosition, null);
            if (indiceLink != -1)
            {
                TMP_LinkInfo linkInfo = _text.textInfo.linkInfo[indiceLink];
                string linkID = linkInfo.GetLinkID();
                Application.OpenURL(linkID);
                //Debug.Log(linkID);
            }

        }
    }
}