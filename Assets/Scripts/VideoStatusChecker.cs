using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class VideoStatusChecker : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public UnityEvent ovideoComplateEvent;
    void Start()
    {
        //videoPlayer = GetComponent<VideoPlayer>();

       
        videoPlayer.prepareCompleted += OnVideoPrepared;
    }

    private void OnVideoPrepared(VideoPlayer vp)
    {
        ovideoComplateEvent?.Invoke();
    }
}
