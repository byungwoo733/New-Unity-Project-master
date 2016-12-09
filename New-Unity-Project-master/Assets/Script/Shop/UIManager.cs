using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
    // 싱글톤 ---
    private static UIManager _instance;
    
    public static UIManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = (UIManager)GameObject.FindObjectOfType(typeof(UIManager));
                
                if (!_instance)
                {
                    GameObject container = new GameObject();
                    container.name = "UIManager";
                    _instance = container.AddComponent(typeof(UIManager)) as UIManager;
                }
            }
            
            return _instance;
        }
    }

    void OnDestroy()
    {
        _instance = null;
    }

    void OnApplicationQuit()
    {
        _instance = null;
    }

    // 씬 전환 및 UI 띄우기.

    public GameObject popups;

    public void OnPopup(GameObject popup)
    {
        popups.SetActive(true);
        currentPopup = popup;
        currentPopup.SetActive(true);
    }

    GameObject currentPopup;

    public void OffPopup()
    {
        popups.SetActive(false);
        currentPopup.SetActive(false);
    }

	// 레벨, 경험치
	public Text TextLevel;
	public Slider SliderExp;

	public Text TextCoin;

	// BarUI : 친밀도, 포만감, 건강 프로그레스바 
	public Slider SliderIntimacy;
	public Slider SliderHealth;
	public Slider SliderSatiety;
	public Text SIText;
	public Text SHText;
	public Text SSText;

	public void UIUpdate()
	{

		TextLevel.text = ( "Lv." + GameManager.Instance.petLevel.ToString());
		SliderExp.value = GameManager.Instance.Exp;
		TextCoin.text = ( "Coin : " + GameManager.Instance.Coin.ToString());

		SliderIntimacy.value = GameManager.Instance.PetIntimacy;
		SIText.text = (SliderIntimacy.value.ToString() + " %");
		SliderHealth.value = GameManager.Instance.PetHealth;
		SHText.text = (SliderHealth.value.ToString() + " %");
		SliderSatiety.value = GameManager.Instance.PetSatiety;
		SSText.text = (SliderSatiety.value.ToString() + " %");
	}



	/*
	public void SetExpUI()
	{
		SliderExp.value = GameManager.Instance.Exp;
	}
	*/

	//
	public Button rotateLeft;
	public Button rotateRight;

	public void RotateLeft(){
		Debug.Log("rotate left buttton");
		GameManager.Instance.playerPet.transform.RotateAround(transform.position, transform.up, 20);
	}

	public void RotateRight(){
		Debug.Log("rotate right buttton");
		GameManager.Instance.playerPet.transform.RotateAround(transform.position, transform.up, -20);
	}





}
