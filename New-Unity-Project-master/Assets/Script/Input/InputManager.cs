using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputManager : MonoBehaviour {

    [SerializeField]
    InputField inputField;

    void Start()
    {
        inputField.ActivateInputField();
        inputField.Select();

        inputField.onValueChanged.AddListener(OnValueChange);
        inputField.onEndEdit.AddListener(OnSubmit);
    }

    public void OnValueChange(string value)
    {
        print("value : " + value);
    }

    public void OnSubmit(string value)
    {
        print("value : " + value);
    }
}
