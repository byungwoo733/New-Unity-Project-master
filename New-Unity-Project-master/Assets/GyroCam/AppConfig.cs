using UnityEngine;
using System.Collections;

public class AppConfig : MonoBehaviour
{
    void Awake()
    {
        // 프레임 고정.
        Application.targetFrameRate = 60;
        // 자이로 사용.
        Input.gyro.enabled = true;
    }
}
