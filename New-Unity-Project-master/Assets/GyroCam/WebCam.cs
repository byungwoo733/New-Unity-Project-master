using UnityEngine;
using System.Collections;

public class WebCam : MonoBehaviour
{
    WebCamTexture webCam;
    
    IEnumerator Start()
    {
        webCam = new WebCamTexture(Screen.width, Screen.height);

        webCam.Play();

        // 웹캠이 업데이트 되는 동안 실행.
        while (!webCam.didUpdateThisFrame) yield return null;
        // mainTexture에 웹캠 입력.
        // 웹캠이 실제 나오게 하는 부분.
        GetComponent<Renderer>().material.mainTexture = webCam;
        
        transform.localRotation = Quaternion.AngleAxis(webCam.videoRotationAngle, -Vector3.forward);
        Debug.Log("WebCamTexture: " + webCam.width + ", " + webCam.height);

        var sy = 2.0f * Screen.width / Screen.height;
        var sx = sy * webCam.width / webCam.height;
        transform.localScale = new Vector3(sx, sy, 1);
    }
}
