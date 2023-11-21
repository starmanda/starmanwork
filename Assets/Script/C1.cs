using UnityEngine;
using UnityEngine.UI;

public class C1 : MonoBehaviour
{
    public Slider speedSlider; // Slider控件
    public Text speedText; // 显示速度的Text组件
    public float minSpeed = 90f; // 最小旋转速度
    public float maxSpeed = 450f; // 最大旋转速度

    private float currentSpeed; // 当前旋转速度

    void Start()
    {
        // 初始化速度为最小速度
        currentSpeed = minSpeed;
        SetRotationSpeed();
        speedText = GetComponent<Text>();

    }

    void Update()
    {
        // 根据当前速度使Cube绕Y轴自转
        transform.Rotate(Vector3.up * currentSpeed * Time.deltaTime);

    }

    // 处理Slider的值改变事件
    public void OnSliderValueChanged()
    {
        // 判断Slider的值
        if (speedSlider.value == speedSlider.minValue)
        {
            // 当Slider的值为最小值时，将速度设置为最小速度
            currentSpeed = minSpeed;
            SetRotationSpeed();
        }
        else if (speedSlider.value == speedSlider.maxValue)
        {
            // 当Slider的值为最大值时，将速度设置为最大速度
            currentSpeed = maxSpeed;
            SetRotationSpeed();
        }
        else
        {
            // 当Slider的值既不为最小值也不为最大值时，将速度设置为最小速度
            speedSlider.value = speedSlider.minValue;
        }
    }

    // 设置速度显示文本
    void SetRotationSpeed()
    {
        speedText.text = currentSpeed + "°/s";
    }
}
