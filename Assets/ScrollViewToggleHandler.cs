using UnityEngine;
using UnityEngine.UI;

public class ScrollViewToggleHandler : MonoBehaviour
{
    public ScrollRect scrollView;
    public Toggle toggle;

    public void Initialize(Toggle toggle)
    {
        this.toggle = toggle;
        scrollView.gameObject.SetActive(toggle.isOn);
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnToggleValueChanged(bool isOn)
    {
        scrollView.gameObject.SetActive(isOn);

        if (isOn)
        {
            // 滚动 ScrollView 到能展示出该内容物体的位置
            RectTransform content = scrollView.content;
            RectTransform toggleTransform = toggle.GetComponent<RectTransform>();
            Vector2 viewportPosition = scrollView.viewport.localPosition;
            Vector2 contentPosition = content.localPosition;
            Vector2 togglePosition = toggleTransform.localPosition;
            float toggleHeight = toggleTransform.rect.height;
        }
    }
}