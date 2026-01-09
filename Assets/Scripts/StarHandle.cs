using UnityEngine;

public class StarHandle : MonoBehaviour
{
    public Star star;
    void Awake()
    {
        if (star == null)
        {
            star = transform.GetComponentInChildren<Star>();
        }
        if (star.starHandle == null)
        {
            star.starHandle = this;
        }
    }

    public void OnClick(int _score = 1)
    {
        GameController.Instance.score += _score;
        star.gameObject.SetActive(false);
        Destroy(gameObject,1.2f);
    }

    // void OnMouseDown()
    // {
    //     Debug.Log("1111");
    // }
}
