using System.Collections;
using UnityEngine;

public class ImageManager : MonoBehaviour
{
    private RectTransform imageA;
    private RectTransform imageB;
    private Vector2 initialSizeDelta;

    void Start()
    {
        imageA = GameObject.Find("ImageA").GetComponent<RectTransform>();
        imageB = GameObject.Find("ImageB").GetComponent<RectTransform>();

        initialSizeDelta = imageB.sizeDelta;

        StartCoroutine(ChangeSizeDeltaDelay());
    }

    void Update()
    {
        if (imageB.sizeDelta.x >= Screen.width / 2)
        {
            imageB.sizeDelta = new Vector2(0, initialSizeDelta.y);
        }

        imageB.sizeDelta += new Vector2(100 * Time.deltaTime, 0);
    }

    IEnumerator ChangeSizeDeltaDelay()
    {
        while (true)
        {
            imageA.sizeDelta = new Vector2(Random.Range(Screen.width / 2, Screen.width), Random.Range(Screen.height / 2, Screen.height));

            yield return new WaitForSeconds(3f);
        }
    }
}