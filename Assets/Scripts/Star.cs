using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Star : MonoBehaviour, IPointerDownHandler
{
    public StarHandle starHandle;
    public int scoreIncrees = 1;
    public UnityEvent onClickEvent;
    public void OnPointerDown(PointerEventData eventData)
    {
        onClickEvent?.Invoke();
        starHandle.OnClick(scoreIncrees);
    }
    void Awake()
    {
        if (starHandle == null)
        {
            starHandle.transform.parent.GetComponent<StarHandle>();
        }
        if (starHandle.star == null)
        {
            starHandle.star = this;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        //  starHandle.OnClick(scoreIncrees);
        // Debug.Log("2222");
    }


}
