using UnityEngine;
using UnityEngine.UI;

public class Hello : MonoBehaviour
{
    public GameObject Cube;
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
        speedSlider.minValue = minSpeed;
        speedSlider.maxValue = maxSpeed;//取整设置为否
        speedSlider.wholeNumbers = false;
        //当SliderVulue值变化时,调用对应方法
        speedSlider.onValueChanged.AddListener(OnValueChanged);
    }
    /// <summary>
    /// 当Slider的Value值发生变化时,调用该方法
    ///  </summary>
    ///   <param name="value"></param>该值为value值变化后的值
    void OnValueChanged(float value)
    {
        currentSpeed = value;
       speedText.text = $"旋转 {value}°/s";
    }
    void Update()
    {
        Cube.transform.Rotate(0f, currentSpeed * Time.deltaTime, 0f);
        
    }
    public void OnHandleClick()
    {
        if (speedSlider.value == speedSlider.minValue)
        {
            speedSlider.value = speedSlider.maxValue;
            
        }
       
        else
        {
            speedSlider.value = speedSlider.minValue;
           
        }
    }
    private void SetRotationSpeed()
    {
        speedText.text = "旋转"+ currentSpeed + "°/s";
    }

}
