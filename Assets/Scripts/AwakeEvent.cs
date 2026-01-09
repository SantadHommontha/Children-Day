using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class AwakeEvent : MonoBehaviour
{
    public UnityEvent awakeEvent;
    public void Awake()
    {
        awakeEvent?.Invoke();
    }
}
