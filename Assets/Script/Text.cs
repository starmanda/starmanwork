using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour
{
    public GameObject cube;
    public string text;

    private void Update()
    {
        transform.position = cube.transform.position + Vector3.forward * 10;

        // 按照 Cube 的 Z 轴坐标大小排序 Text  
        int zIndex = (int)cube.transform.position.z;
        Text[] allTexts = FindObjectsOfType<Text>();
        for (int i = 0; i < allTexts.Length; i++)
        {
            Text otherText = allTexts[i];
            if (otherText.cube == cube)
            {
                continue;
            }

            if (zIndex > otherText.cube.transform.position.z)
            {
                otherText.transform.position = new Vector3(otherText.transform.position.x, otherText.transform.position.y, zIndex - 1);
            }
        }
    }
}
