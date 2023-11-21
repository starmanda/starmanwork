using UnityEngine;
using UnityEngine.UI;

public class C6 : MonoBehaviour
{
    public ScrollRect scrollRect;
    public Button switchButton;
    public GameObject itemPrefab;
    public Transform content;

    private bool isHorizontalScroll = true;

    void Start()
    {
        
        switchButton.onClick.AddListener(OnSwitchButtonClick);
        GenerateItems(20); // 生成20个子物体
    }

    void OnSwitchButtonClick()
    {
        isHorizontalScroll = !isHorizontalScroll;
        scrollRect.horizontal = isHorizontalScroll;
        scrollRect.vertical = !isHorizontalScroll;

        ArrangeItems();
    }

    void GenerateItems(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject item = Instantiate(itemPrefab, content);
            item.GetComponentInChildren<Text>().text = i.ToString();
        }
        ArrangeItems();
    }

    void ArrangeItems()
    {
        for (int i = 0; i < content.childCount; i++)
        {
            RectTransform child = content.GetChild(i) as RectTransform;
            if (isHorizontalScroll)
            {
                child.anchorMin = new Vector2(i * 1.0f / content.childCount, 0);
                child.anchorMax = new Vector2((i + 1) * 1.0f / content.childCount, 1);
            }
            else
            {
                child.anchorMin = new Vector2(0, i * 1.0f / content.childCount);
                child.anchorMax = new Vector2(1, (i + 1) * 1.0f / content.childCount);
            }
            child.offsetMin = Vector2.zero;
            child.offsetMax = Vector2.zero;
        }
    }
}
