using UnityEngine;
using UnityEngine.UI;

public class C1 : MonoBehaviour
{
    private InputField inputField;

    private void Awake()
    {
        inputField = GetComponent<InputField>();
        inputField.onValueChanged.AddListener(OnInputValueChanged);
    }

    private void OnInputValueChanged(string value)
    {
        // 只允许输入整数
        int intValue;
        if (!int.TryParse(value, out intValue))
        {
            inputField.text = "";
        }
    }
}