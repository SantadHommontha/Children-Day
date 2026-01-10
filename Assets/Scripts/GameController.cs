using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public GameObject scene1;
    public GameObject scene2;
    public GameObject scene3;
    public GameObject scene4;

    public float gameTime = 10f;
    public float timer = 0;

    

    public UnityEvent timerOverEvent;
    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;
    }


    public int score = 0;
    void Start()
    {
        scene1.SetActive(true);
        scene2.SetActive(false);
        scene3.SetActive(false);
        scene4.SetActive(false);
    }

    public void SetUp()
    {
        score = 0;
        timer = gameTime;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartTimer()
    {
        SetUp();
        StartCoroutine(TimerCount());
    }

    public void StopTimer()
    {
        StopCoroutine(TimerCount());
    }

    private IEnumerator TimerCount()
    {
        // // 10 < 0
        // if (timer < 0)
        // {
        //     Debug.Log("T" + timer);
        // }
        // else
        // {
        //     Debug.Log("F " + timer);
        // }

        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
     //   Debug.Log("2222");
        timerOverEvent?.Invoke();
    }
}
