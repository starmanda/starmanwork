using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.UI;  
  
public class C4 : MonoBehaviour  
{  
    public Slider slider; // 引用Slider组件  
    public Text text; // 引用Text组件  
    public float minRotationSpeed = 90.0f; // 最小旋转速度（每秒度数）  
    public float maxRotationSpeed = 450.0f; // 最大旋转速度（每秒度数）  
    private float rotationSpeed; // 当前旋转速度  
    private float previousValue; // 记录上一次Slider的值
    private Button button;
  
    // Start is called before the first frame update  
    void Start()  
    {  
        rotationSpeed = minRotationSpeed; // 初始化旋转速度为最小速度  
        button = slider.handleRect.gameObject.AddComponent<Button>();
        button.onClick.AddListener(OnHandleClick);
        slider.onValueChanged.AddListener(OnValueChanged);
    }
    void OnValueChanged(float value)
    {
        rotationSpeed = slider.value;
        text.text = $"旋转 {value}°/s";
    }

    // Update is called once per frame  
    void Update()  
    {  
        // 根据旋转速度更新Cube的旋转角度  
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);  
    }
    void UpdateRotationSpeed()
    {
        if (slider.value == slider.minValue)
        {
            slider.value = slider.maxValue;
            rotationSpeed = maxRotationSpeed;
        }
        else if (slider.value == slider.maxValue)
        {
            slider.value = slider.minValue;
            rotationSpeed = minRotationSpeed;
        }
        else
        {
            slider.value = slider.minValue;
            rotationSpeed = minRotationSpeed;
        }
        // 将旋转速度赋值给Text组件并更新显示的速度值  
        
    }

    void HandleSliderValue()  
    {
        UpdateRotationSpeed(); // 调用UpdateRotationSpeed方法更新旋转速度 
        // 将旋转速度赋值给Text组件  
        text.text = "Rotation Speed: " + rotationSpeed.ToString() + " degrees per second"; 
        
        previousValue = slider.value;   
    }

    public void OnHandleClick()
    {
        if (slider.value == slider.minValue)
        {
            slider.value = slider.maxValue;

        }

        else
        {
            slider.value = slider.minValue;

        }
    }
}