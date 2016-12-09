using UnityEngine;
using System.Collections;

public class PlayerPet : MonoBehaviour
{
	public GameObject movingPoint = null;


	Vector3 mousePoint;
	int count = 0;

	// Animator 지정
	Animator anim;

	// PetFeeling
	public string petFeeling = "Love";

	// Cat의 상태 
	enum CatState
	{
		Idle,
		Nail,
		NailFinish,
		Wriggle,
		WriggleFinish,
		Cry,
		Pick,
		Crycry,
		Walk
	};
	CatState state;

	// Use this for initialization
	void Start()
	{
		state = CatState.Idle;
		anim = gameObject.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		switch (state)
		{
			case CatState.Idle:
				Idle();
				break;
			case CatState.Nail:
				Nail();
				break;
			case CatState.NailFinish:
				NailFinish();
				break;
			case CatState.Wriggle:
				Wriggle();
				break;
			case CatState.WriggleFinish:
				WriggleFinish();
				break;
			case CatState.Cry:
				Cry();
				break;
			case CatState.Pick:
				Pick();
				break;
			case CatState.Crycry:
				Crycry();
				break;
			case CatState.Walk:
				Walk();
				break;
		}
	}

	void Idle()
	{ }

	void Nail()
	{ }

	void NailFinish()
	{ }

	void Wriggle()
	{ }

	void WriggleFinish()
	{ }

	void Cry()
	{ }

	float currentTime = 0;
	public float pickTime = 5;
	void Pick()
	{
		currentTime += Time.deltaTime;
		if (currentTime > pickTime)
		{
			currentTime = 0;
			state = CatState.Idle;
			anim.SetBool("Idle_", true);
		}
	}

	void Crycry()
	{ }
    void Walk()
	{
		Vector3 dir = movingPoint.transform.position - transform.position;

		float distance = Vector3.Distance(transform.position, movingPoint.transform.position);
		Debug.Log("distance=" + distance);

		if (distance < 1.0f)
		{
			state = CatState.Idle;
			anim.SetBool("Idle_", true);
			return;
		}

		dir.Normalize();

		transform.forward = Vector3.Lerp(transform.forward, dir, Time.deltaTime);
		transform.position = Vector3.Lerp(transform.position, movingPoint.transform.position, 0.2f * Time.deltaTime);
	}


	public void OnMouseDown()
	{
		mousePoint = Input.mousePosition;
	}


	void OnMouseDrag()
	{
		Vector3 pos = Input.mousePosition;
		float dis = Vector3.Distance(mousePoint, pos);
		if (dis > 20)
		{
			count++;
		}

		if (count == 5)
		{
			if (GameManager.Instance.petFeel == PetFeeling.Love)	
			{
				state = CatState.Nail;
				anim.SetBool("Nail_", true);
			}

			if (GameManager.Instance.petFeel == PetFeeling.Happy)
			{
				state = CatState.Wriggle;
				anim.SetBool("Wriggle_", true);
			}

			if (GameManager.Instance.petFeel == PetFeeling.SoSo)
			{
				state = CatState.Cry;
				anim.SetBool("Cry_", true);
			}

			if (GameManager.Instance.petFeel == PetFeeling.Cry)
			{
				state = CatState.Crycry;
				anim.SetBool("Crycry_", true);
			}
		}
	}

	void OnMouseUp()
	{
		count = 0;
		mousePoint = Vector3.zero;
		print("Up");

		if (GameManager.Instance.petFeel == PetFeeling.Love)
		{
			print("love");
			state = CatState.NailFinish;
			anim.SetBool("Nail_", false);
		}


		if (GameManager.Instance.petFeel == PetFeeling.Happy)
		{
			state = CatState.WriggleFinish;
			anim.SetBool("Wriggle_", false);
		}


		if (GameManager.Instance.petFeel == PetFeeling.SoSo)
		{
			state = CatState.Pick;
			anim.SetBool("Cry_", false);
		}


		if (GameManager.Instance.petFeel == PetFeeling.Cry)
		{
			state = CatState.Walk;
			anim.SetBool("Crycry_", false);
        }

	}
}



