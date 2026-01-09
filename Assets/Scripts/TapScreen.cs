using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TapScreen : MonoBehaviour ,IPointerDownHandler
{

    public UnityEvent tapEvent;
    public void OnPointerDown(PointerEventData eventData)
    {
        tapEvent?.Invoke();
    }

   
}
