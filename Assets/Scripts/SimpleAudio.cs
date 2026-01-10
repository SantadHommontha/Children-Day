using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class SimpleAudio : MonoBehaviour
{
    [Header("Audio List")]
    public List<AudioClip> audioClips; 

    [Header("Settings")]
    public bool playOnStart = false;
    public bool loop = false;

  [SerializeField]  private AudioSource audioSource;
    private Coroutine fadeCoroutine;

    void Awake()
    {
       if(audioSource == null) audioSource = GetComponent<AudioSource>();
        audioSource.loop = loop;
    }

    void Start()
    {
        if (playOnStart && audioClips.Count > 0)
        {
            PlayRandomAudio();
        }
    }

    
    public void PlayAudio(int index)
    {
        if (index < 0 || index >= audioClips.Count) return;
        ExecutePlay(audioClips[index]);
    }

   
    public void PlayRandomAudio()
    {
        if (audioClips.Count == 0) return;

        int randomIndex = Random.Range(0, audioClips.Count);
        ExecutePlay(audioClips[randomIndex]);
    }

   
    private void ExecutePlay(AudioClip _clip)
    {
        if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
       
        audioSource.clip = _clip;
        audioSource.volume = 1f; 
        audioSource.Play();
    }

   public void StopAudio() => StopAudio(false,1f);

    public void StopAudio(bool useFadeOut = false, float fadeDuration = 1.0f)
    {
        if (useFadeOut)
        {
            if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
            fadeCoroutine = StartCoroutine(FadeOutAndStop(fadeDuration));
        }
        else
        {
            audioSource.Stop();
        }
    }

   

    public void SetLoop(bool isLooping)
    {
        loop = isLooping;
        audioSource.loop = isLooping;
    }

   
    private IEnumerator FadeOutAndStop(float duration)
    {
        float startVolume = audioSource.volume;

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / duration);
            yield return null;
        }

        audioSource.volume = 0;
        audioSource.Stop();
        audioSource.volume = startVolume; 
    }
}
