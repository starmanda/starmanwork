using UnityEngine;
using UnityEngine.UI;

public class Circle : MonoBehaviour
{
    public Image circleImage; // 对应"Circle"对象下的Image组件
    public float duration = 2f; // 显示和消失的总时间
    private float timer = 0f;
    private bool isShowing = true;

    void Start()
    {
        timer = 0f;
        isShowing = true;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (isShowing)
        {
            float fillAmount = Mathf.Clamp01(timer / duration);
            circleImage.fillAmount = fillAmount;
        }
        else
        {
            float fillAmount = Mathf.Clamp01((duration - timer) / duration);
            circleImage.fillAmount = fillAmount;
        }

        if (timer >= duration)
        {
            timer = 0f;
            isShowing = !isShowing;
        }
    }
}
