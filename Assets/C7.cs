using UnityEngine;
using UnityEngine.UI;

public class C7 : MonoBehaviour
{
    public ToggleGroup toggleGroup;
    public GameObject[] seatPanels;
    public Text[] seatTexts;
    public Image[] seatImages;

    private int[] seatStatus = { 0, 1, 0, 1, 1 }; // 座位状态，0表示无人，1表示有人

    private void Start()
    {
        // 初始化座位信息
        for (int i = 0; i < seatPanels.Length; i++)
        {
            seatTexts[i].text = (i + 1).ToString(); // 座位序号从1开始
            if (seatStatus[i] == 0)
            {
                seatImages[i].color = Color.red; // 无人，显示红色
            }
            else
            {
                seatImages[i].color = Color.green; // 有人，显示绿色
            }
        }
    }

    public void OnToggleChanged()
    {
        // 监听Toggle的选中事件
        foreach (Toggle toggle in toggleGroup.ActiveToggles())
        {
            int index = int.Parse(toggle.name) - 1; // 座位索引从0开始，需要减1
            seatPanels[index].SetActive(true); // 显示对应座位的ScrollView
        }

        // 关闭其他ScrollView
        for (int i = 0; i < seatPanels.Length; i++)
        {
            if (!toggleGroup.AnyTogglesOn() || !seatPanels[i].activeSelf)
            {
                seatPanels[i].SetActive(false);
            }
        }
    }
}
