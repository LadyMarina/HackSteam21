using UnityEngine;
using UnityEngine.EventSystems;

namespace HackStem
{
    public class NumberBlockSlot : MonoBehaviour , IDropHandler
    {
        public bool Filled { get; set; } = false;
        
        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag != null)
            {
                Filled = true;
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                    GetComponent<RectTransform>().anchoredPosition;
            }
        }
    }
}