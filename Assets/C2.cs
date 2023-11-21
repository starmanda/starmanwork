using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class C2 : MonoBehaviour
{
    public InputField inputField;
    public ToggleGroup toggleGroup;
    public ScrollRect[] scrollRects;

    public GameObject contentPrefab;

    private void Start()
    {
        inputField.contentType = InputField.ContentType.IntegerNumber;
        inputField.onEndEdit.AddListener(OnInputEndEdit);

        for (int i = 0; i < scrollRects.Length; i++)
        {
            int index = i; // 保存当前的索引值
            Toggle toggle = InstantiateToggle(i);
            toggle.onValueChanged.AddListener((value) => OnToggleValueChanged(index, value)); // 使用保存的索引值
        }

    }

    private Toggle InstantiateToggle(int index)
    {
        Toggle toggle = new GameObject("Toggle" + index).AddComponent<Toggle>();
        toggle.transform.SetParent(transform);
        toggle.group = toggleGroup;
        return toggle;
    }

    private void OnToggleValueChanged(int index, bool value)
    {
        if (value)
        {
            scrollRects[index].gameObject.SetActive(true);
            scrollRects[index].gameObject.GetComponent<ScrollRect>().normalizedPosition = new Vector2(0, 1);
        }
        else
        {
            scrollRects[index].gameObject.SetActive(false);
        }
    }

    private void OnInputEndEdit(string text)
    {
        int seatIndex = int.Parse(text);
        int scrollRectIndex = CalculateScrollRectIndex(seatIndex);
        toggleGroup.NotifyToggleOn(toggleGroup.ActiveToggles().First(), false);
        toggleGroup.NotifyToggleOn(toggleGroup.GetComponentsInChildren<Toggle>()[scrollRectIndex], true);
        scrollRects[scrollRectIndex].gameObject.SetActive(true);
        scrollRects[scrollRectIndex].gameObject.GetComponent<ScrollRect>().normalizedPosition = new Vector2(0, 1);
    }

    private int CalculateScrollRectIndex(int seatIndex)
    {
        // 根据座位索引计算对应的ScrollRect索引，这里只是一个简单的示例，实际应用中可能需要根据具体的座位排布规则进行计算
        return seatIndex % scrollRects.Length;
    }
}
