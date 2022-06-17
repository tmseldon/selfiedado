using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class BackgroundOverlay : MonoBehaviour
    {
        [SerializeField] float _speedX = 88f;
        [SerializeField] Canvas _canvasParent;

        private Vector3 _initialPos;
        private float _repeatWidth;

        void Start()
        {
            _initialPos = transform.position;
            _repeatWidth = GetComponent<RectTransform>().rect.width / 2 * _canvasParent.scaleFactor;
        }

        void Update()
        {
            if (transform.position.x < _initialPos.x - _repeatWidth)
            {
                transform.position = _initialPos;
            }

            transform.Translate(Vector3.left * _speedX * Time.deltaTime, Space.World);
        }
    }

}