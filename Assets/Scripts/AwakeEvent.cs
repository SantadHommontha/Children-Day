using UnityEngine;
using UnityEngine.Events;

public class AwakeEvent : MonoBehaviour
{
    public UnityEvent awakeEvent;
    public void Awake()
    {
        awakeEvent?.Invoke();
    }
}
