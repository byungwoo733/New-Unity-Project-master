using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public GameObject[] petStateParticle;
    
    void Start()
    {
        Init();
    }

    public void Init()
    {
        // 상태에 따른 파티클.
        if (GameManager.Instance.petFeel == PetFeeling.Love)
        {
            petStateParticle[0].SetActive(true);
        }
    }

	void Update () {
        if (GameManager.Instance.isGameStop) return;
        /*
        // 마우스 클릭시 포인트 지정.
	    if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            
            if (Physics.Raycast(ray, out hit, 500))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    print(hit.transform.tag);
                }
                if (hit.transform.CompareTag("UI"))
                {
                    print(hit.transform.tag);
                }
                if (hit.transform.CompareTag("Place"))
                {
                    transform.position = hit.point;
                    print(hit.transform.tag);
                }
            }
        }
        */
	}
}
