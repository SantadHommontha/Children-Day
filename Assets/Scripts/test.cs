using UnityEngine;
using UnityEngine.EventSystems;

public class test : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("11111");
    }

    void OnMouseDown()
    {
         Debug.Log("2222");
    }
}
