using UnityEngine;

public class StarHandle : MonoBehaviour
{
    public Star star;
    public bool isWhiteStar = false;
    public int scoreClick = 1;
    public float timeToDestroyWhileWhileStar = 0.4f;
    private float timer = 0;
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

    public void OnClick()
    {
        OnClick(scoreClick);
    }
    public void OnClick(int _score)
    {
        if (isWhiteStar)
        {
            GameController.Instance.score -= _score;
        }
        else
        {
            GameController.Instance.score += _score;
        }
        star.gameObject.SetActive(false);
        Destroy(gameObject, 1.2f);
    }
    private void Update()
    {
        if(isWhiteStar)
        {
            if(timer <= timeToDestroyWhileWhileStar)
            {
                timer += Time.deltaTime;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    // void OnMouseDown()
    // {
    //     Debug.Log("1111");
    // }
}
