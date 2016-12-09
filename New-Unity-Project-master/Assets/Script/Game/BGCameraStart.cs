using UnityEngine;
using System.Collections;

public class BGCameraStart : MonoBehaviour {

    public GameObject BGCamera;

    void Start()
    {
        Invoke("Show", 0.5f);
    }

	void Show ()
    {
        BGCamera.SetActive(true);
	}
	

}
