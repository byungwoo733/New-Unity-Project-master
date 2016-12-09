using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveManager : MonoBehaviour {

    public float disDefine;

    public CameraPivot camPivot;
    Quaternion originalRot;

    public GameObject plane;
    Vector3 pos;

    public Text originalText;

    float MAXMOVE = 4f;
    float moveInterpolation;
    float oldInterpolation;


    IEnumerator Start()
    {
        disDefine = 0.2f;

        yield return new WaitForSeconds(0.1f);
        // originalRot = camPivot.transform.localRotation;

        //camPivot.transform.localRotation = new Quaternion(0, 0, 0, 0);
        //originalRot = camPivot.transform.localRotation;

    }

    bool isMove;
    void Update ()
    {
        originalText.text =
            "isMove : " + isMove
            + "\nCamLocalRotation : " + Camera.main.transform.localRotation
            + "\nCamRotation : " + Camera.main.transform.rotation
            + "\noldInterpolation : " + oldInterpolation
            + "\ncamPivot.transform.localRotation.x : " + camPivot.transform.localRotation.x
            + "\nmoveInterpolation : " + moveInterpolation
            + "\nplaneTransformPosition : " + plane.transform.position;

        // 1. 이동한 Rotation값의 소수점 2자리까지 확보.
        // 1-1. Vector3
        Vector3 nPos = camPivot.transform.localRotation.eulerAngles;
        moveInterpolation = Mathf.Floor(nPos.x * 100f)/100f;
        
        // 2. 만약 이동을 했다면.
        if (oldInterpolation != moveInterpolation) isMove = true;  else isMove=false;
        if (isMove)
        {
            // 플레이를 Rotation값만큼 x축으로 이동.
            pos.y = moveInterpolation * -1;
            //pos.y = 0;
           // plane.transform.localRotation = pos;
            
        }
        
        // 현재 moveInterpolation값을 old로 입력
        oldInterpolation = moveInterpolation;

    }
}
