using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class C5 : MonoBehaviour
{
    public Button button;
    public Text displayText;
    private string fullString = "2023.10.23_0210189_xyj";
    private int currentIndex = 0;
    private bool isButtonClicked = false;
    private bool isButtonSelected = false;
    private float rotationSpeed = 5f;

    void Start()
    {
        InvokeRepeating("UpdateDisplayText", 1f, 1f);
        button.onClick.AddListener(OnButtonClick);
        button.onClick.AddListener(ChangeButtonColor);
    }

    private void Update()
    {
        if (!isButtonClicked)
        {
            RotateButton();
        }
        else if (isButtonSelected)
        {
            ChangeButtonColor();
        }
    }

    public void OnButtonClick()
    {
        isButtonClicked = true;
        StartCoroutine(ScaleButton());
    }

    private void UpdateDisplayText()
    {
        if (currentIndex <= fullString.Length)
        {
            displayText.text = GetFormattedString(currentIndex);
            currentIndex++;
        }
        else
        {
            CancelInvoke("UpdateDisplayText");
        }
    }

    private string GetFormattedString(int length)
    {
        string date = "<size=32>" + fullString.Substring(0, length) + "</size>";
        string id = "<size=16><color=blue>" + fullString.Substring(5, 4) + "</color></size>";
        string name = "<size=64><color=red>" + fullString.Substring(10) + "</color></size>";
        return date + "_" + id + "_" + name;
    }

    private void RotateButton()
    {
        float zRotation = Mathf.PingPong(Time.time * rotationSpeed, 10) - 5;
        transform.rotation = Quaternion.Euler(0, 0, zRotation);
    }

    private IEnumerator ScaleButton()
    {
        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = originalScale * 1.3f;
        float duration = 0.3f;
        float startTime = Time.time;
        while (Time.time < startTime + duration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, (Time.time - startTime) / duration);
            yield return null;
        }
        transform.localScale = targetScale;
    }

    void ChangeButtonColor()
    {
        Color[] colors = { Color.red, Color.yellow, Color.green, Color.cyan, Color.blue, Color.magenta, Color.red };
        int index = Mathf.FloorToInt(Time.time / 10) % colors.Length;
        GetComponent<Image>().color = colors[index];
    }
}
