using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System.Collections.Generic;

public class WebGLScreenshot : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void DownloadImageJS(string base64, string fileName);
    public List<GameObject> hideUI = new List<GameObject>();
    public void TakeScreenshot()
    {
        StartCoroutine(CaptureRoutine());
    }

    private IEnumerator CaptureRoutine()
    {
        foreach (var T in hideUI)
        {
            T.SetActive(false);
        }
        yield return new WaitForEndOfFrame();


        Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);


        screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenshot.Apply();


        byte[] bytes = screenshot.EncodeToPNG();
        Destroy(screenshot);


        string base64 = "data:image/png;base64," + System.Convert.ToBase64String(bytes);


#if UNITY_WEBGL && !UNITY_EDITOR
            DownloadImageJS(base64, "MyGameScreenshot.png");
#else
        Debug.Log("Screenshot Captured! (Download only works in WebGL Build)");
#endif


        foreach (var T in hideUI)
        {
            T.SetActive(true);
        }
    }
}
