using UnityEngine;
using UnityEngine.UI;

public class C8 : MonoBehaviour
{
    public InputField inputField;
    public Toggle[] seatToggles;
    public ScrollRect[] seatScrollViews;
    public GameObject seatContentPrefab;

    private void Start()
    {
        inputField.onEndEdit.AddListener(OnInputFieldEndEdit);
        for (int i = 0; i < seatToggles.Length; i++)
        {
            int index = i; // Capture the current value of i in the lambda expression
            seatToggles[i].onValueChanged.AddListener((value) => OnSeatToggleValueChanged(index, value));
        }
    }

    private void OnInputFieldEndEdit(string text)
    {
        if (int.TryParse(text, out int seatNumber))
        {
            if (seatNumber >= 0 && seatNumber < seatScrollViews.Length)
            {
                seatScrollViews[seatNumber].gameObject.SetActive(true);
                seatToggles[seatNumber].isOn = true;
                ScrollToSeat(seatScrollViews[seatNumber], seatNumber);
            }
        }
    }

    private void OnSeatToggleValueChanged(int index, bool value)
    {
        if (value)
        {
            seatScrollViews[index].gameObject.SetActive(true);
            ScrollToSeat(seatScrollViews[index], index);
        }
    }

    private void ScrollToSeat(ScrollRect scrollView, int seatNumber)
    {
        int contentCount = scrollView.content.childCount;
        float contentHeight = scrollView.content.sizeDelta.y;
        float viewportHeight = scrollView.viewport.rect.height;
        float targetY = (seatNumber + 0.5f) / contentCount * contentHeight - viewportHeight / 2f;
        scrollView.normalizedPosition = new Vector2(0, Mathf.Clamp01(targetY / (contentHeight - viewportHeight)));
    }
}
