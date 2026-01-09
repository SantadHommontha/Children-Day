using UnityEngine;
using UnityEngine.Video;

public class Player_Video : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    void Awake()
    {
        videoPlayer.playOnAwake = false;
    }
    void Start()
    {

    }
    public void StopVideo()
    {
        videoPlayer.Stop();
    }

    public void PlayVideo()
    {
        videoPlayer.Play();
    }
}
