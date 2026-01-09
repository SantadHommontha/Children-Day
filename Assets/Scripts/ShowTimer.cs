using TMPro;
using UnityEngine;

public class ShowTimer : MonoBehaviour
{
    public TMP_Text text;
    void Update()
    {
        if (text)
        {
            text.text = GameController.Instance.timer.ToString("F0");
        }
    }
}
