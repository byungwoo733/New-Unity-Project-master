using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraPivot : MonoBehaviour
{
    public Text webcamText;

    void Update()
    {
        // 장치의 attitude 반환.
        Quaternion q1 = Input.gyro.attitude;
        // 축 교환.
        Quaternion q2 = new Quaternion(q1.y, -q1.z, -q1.x, q1.w);

        transform.localRotation = q2;

        webcamText.text = "CameraPivotlocalRotation : " + transform.localRotation;
    }
}
