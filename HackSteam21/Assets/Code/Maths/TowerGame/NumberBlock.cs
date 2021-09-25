using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HackStem
{
    public class NumberBlock : MonoBehaviour , IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        private string _operation = String.Empty;
        private Image _blockBackground;
        private Text _text;

        private RectTransform _rectTransform;
        private Canvas _canvas;

        private void Awake()
        {
            _blockBackground = GetComponent<Image>();
            _text = GetComponentInChildren<Text>();
            _rectTransform = GetComponent<RectTransform>();
            _canvas = GetComponentInParent<Canvas>();
        }

        public void SetOperation(string operation)
        {
            _operation = operation;
            _text.text = operation;
        }

        public string GetOperation()
        {
            return _operation;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _blockBackground.raycastTarget = false;
            _text.raycastTarget = false;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _blockBackground.raycastTarget = true;
            _text.raycastTarget = true;
        }
    }
}