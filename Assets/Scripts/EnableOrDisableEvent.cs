using UnityEngine;
using UnityEngine.Events;
public class EnableOrDisableEvent : MonoBehaviour
{
    public UnityEvent enableEvent;
    public UnityEvent disableEvent;

   

    void OnEnable()
    {
       
        enableEvent?.Invoke();
    }
    void OnDisable()
    {
        disableEvent?.Invoke();
    //    Debug.Log("disableEvent is null!");
    }
}
