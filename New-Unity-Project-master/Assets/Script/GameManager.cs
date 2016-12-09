using UnityEngine;
using System.Collections;

public enum PetFeeling
{
	Love = 0,
	Happy,
	SoSo,
	Cry,
};

public class GameManager : MonoBehaviour {

	#region 싱글톤.
    // SINGLETON

        // 싱글톤은 Static 변수로 정의 하기 때문에, 파괴되든 파괴되지 않던 상관 없이 메모리상에 남음.
        // 일단 static GameManager의 변수에 값이 들어가면 그 메모리를 놓아주지 않는 이상 메모리에 남아서 사용 가능.
        // 중복 생성 및 씬 전환에 따른 중복을 막기 위해 아래와 같이 처리.

    // 싱글톤 용 변수.
    private static GameManager _instance;

    // 외부 접근용 변수.
    // 함수 같지만, 함수가 아님. 매개변수 없음. Get, Set 처리용.
    public static GameManager Instance
    {
        // Get, Set 이라고 하는 사용법이며, Get은 받아올때, Set은 변경할때 사용.
        // 싱글톤은 받아서 사용만 하면 되기 때문에 Set 처리는 불필요.
        // 겟처리.
        get
        {
            // 인스턴스가 null 일때.
            if (!_instance)
            {
                // 오브젝트가 있다면 획득. (씬 상에 배치 해 뒀을 경우 처리 부분).
                _instance = (GameManager)GameObject.FindObjectOfType(typeof(GameManager));

                // 씬 상에 미 배치시 처리 부분.
                if (!_instance)
                {
                    // 게임 오브젝트 생성.
                    GameObject container = new GameObject();
                    // 이름 변경.
                    container.name = "GameManager";
                    // 메니져 스크립트 추가.
                    _instance = container.AddComponent(typeof(GameManager)) as GameManager;
                }
            }

            // 겟 리턴 변수.
            return _instance;
        }
    }

    // 오브젝트가 파괴 될때 스태틱 변수 놓아주기.
    void OnDestroy()
    {
        _instance = null;
    }

    // 어플이 종료 될때 스태틱 변수 놓아주기.
    void OnApplicationQuit()
    {
        _instance = null;
    }

	#endregion

	#region 시작과 동시에 처리해야할 부분.

	// 시작과 동시에 정보 읽어 오기.
    void Awake()
    {
		LoadStateDate();
		SetPetFeel();
		// 코루틴 시작.
		StartCoroutine(DropState());
    }

	// 데이터 저장은 정보가 갱신될때마다 저장됨.
	// 하단의 각 정보들 확인.

    // 데이터 불러오기.
    void LoadStateDate()
    {
        PlayerPrefs.GetFloat("Exp", exp);
        PlayerPrefs.GetFloat("PetIntimacy", petIntimacy);
        PlayerPrefs.GetFloat("PetHealth", petHealth);
        PlayerPrefs.GetFloat("PetSatiety", petSatiety);
    }

	#endregion

	#region 각종 변수들.

    // UI 정보 처리. (public Get, Set 으로 처리).

    // Game Data
    // 여기에 게임 필요 변수 선언.

    // 게임 정지.
    public bool isGameStop = false;
        
    // Pet Data - struct or class로 묶을 수 있음.

    // Level.
    public int petLevel;

    // 펫 이름.
    public string petName = "";

    // 경험치.
    // 먹이에 따른 증가 : 기본 먹이 - 경험치(레벨 * 1) 증가
    // 고급 먹이 - 먹이표에 따라 증가.
    // 놀아주기 - 추후 아이템 고민.
    float exp;
    public float Exp
    {
        get { return exp; }
        set
        {
            exp += value;
            Mathf.Clamp(exp, 0, 100);
            PlayerPrefs.SetFloat("Exp", exp);
        }
    }
    // 돈.
    // 증가 : 산책 - 코인 1개 : 50% // 3개 : 30% // 5개 : 10% //// 10% 사라짐 // 아뭇것도 못얻을 확률?.
    int coin;
    public int Coin
    {
        get { return coin; }
        set
        {
            coin += value;
            Mathf.Clamp(coin, 0, 100);
        }
    }
    // 친밀도.
    // 증가 : 쓰다듬기 - 0.5 증가.
    // 고급 먹이 - 먹이표에 따라 증가.
    // 산책 - 시간 < 10분 : 10증가 // 시간 >= 10분 : 20증가.
    // 감소 : 시간에 따라 - 1시간당 5감소(60분 - 3600초).
    float petIntimacy;
    public float PetIntimacy
    {
        get { return petIntimacy; }
        set
        {
            petIntimacy += value;
            Mathf.Clamp(petIntimacy, 0, 100);
            PlayerPrefs.SetFloat("PetIntimacy", petIntimacy);
        }
    }
    // 건강.
    // 증가 : 고급먹이 - 먹이표에 따라.
    // 영양제 - 추후 고민.
    // 감소 : 산책 - 시간 < 10분 : 10감소 // 시간 >= 10분 : 30 감소.
    float petHealth;
    public float PetHealth
    {
        get { return petHealth; }
        set
        {
            petHealth += value;
            Mathf.Clamp(petHealth, 0, 100);
            PlayerPrefs.SetFloat("PetHealth", petHealth);
        }
    }
    // 포만감.
    // 증가 : 먹이 - 기본 : 5증가 // 고급 : 표에 따라.
    // 감소 : 산책 - 시간 < 10분 : 30 감소 // 시간 >= 10분 : 50감소.
    // 시간당 5감소(3600초).
    float petSatiety;
    public float PetSatiety
    {
        get { return petSatiety; }
        set
        {
            petSatiety += value;
            Mathf.Clamp(petSatiety, 0, 100);
            PlayerPrefs.SetFloat("PetSatiety", petSatiety);
        }
    }

    // 펫 감정.
	public PetFeeling petFeel;

	//감정 가중치.
	float petIntimacyOffSet = 1;
	float PetHealthOffSet = 1;
	float PetStateOffSet = 1;



    // 모든 관계 연결.
    public PlayerPet playerPet;
    public Transform originalPos;                       // 펫의 처음 위치.

	#endregion

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	#region 펫 활성화되고 난 뒤에 처리해야할 부분.

    // Play Init.
    public bool isPlayReady = false;

    /// <summary>
    /// 펫이 활성화되고 난 이후 처리해야할 부분.
    /// </summary>
	public void InitStatePlay()
    {
        // 1. 펫 대기상태.
        // isPlayReady = false;
    }

	#endregion

	#region 각종 상태 정보 및 감정 처리.

	/// <summary>
	/// exp : 경험치 증감.
	/// intimacy : 친밀도 증감.
	/// health : 건강 증감.
	/// satiety : 포만감 증감.
	/// </summary>
	/// <param name="_exp">Exp.</param>
	/// <param name="_inta">Inta.</param>
	/// <param name="_heath">Heath.</param>
	/// <param name="_sati">Sati.</param>
	public void SetStateData(float _exp, float _intimacy, float _health, float _satiety)
	{
		Exp = _exp;
		PetIntimacy = _intimacy;
		PetHealth = _health;
		PetSatiety = _satiety;
		// 정보가 갱신될때마다 펫 감정 확인.
		SetPetFeel();

        // UI 반영.
        uiManager.UIUpdate();
        // Save.
	}

    public UIManager uiManager;

    // 펫 감정에 따른 파티클. - 조원길 1208.
    public Player player;

	// 펫 감정 셋팅.
    void SetPetFeel()
	{
		float feelValue = ((PetIntimacy * petIntimacyOffSet) + (PetHealth * PetHealthOffSet) + (PetSatiety * PetStateOffSet)) / 3;

		if(feelValue == 100f)
		{
			petFeel = PetFeeling.Love;
            player.Init();
		}
		else if(feelValue >= 70)
		{
			petFeel = PetFeeling.Happy;
		}
		else if(feelValue >= 30)
		{
			petFeel = PetFeeling.SoSo;
		}
		else
		{
			petFeel = PetFeeling.Cry;
		}
	}

	#endregion

	#region 시간에 따른 상태 정보 감소.

	// 1이 1초, 1분이 60초, 1시간이 3600초.
	float dropStateTime = 3600;

	IEnumerator DropState()
	{
		yield return new WaitForSeconds(dropStateTime);

        // 수치값 조절 필요.
        SetStateData(0, -5, -5, -5);

		SetPetFeel();
	}

	#endregion
}