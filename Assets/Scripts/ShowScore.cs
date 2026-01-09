using TMPro;
using UnityEngine;

public class ShowScore : MonoBehaviour
{
    public TMP_Text text;
    // Update is called once per frame
    void Update()
    {
        if (text)
        {
            text.text = GameController.Instance.score.ToString();
        }
    }
}
