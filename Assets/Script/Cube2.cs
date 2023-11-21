using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cube2 : MonoBehaviour
{
    public Text[] infoTexts; // 存储姓名、学号、日期、江西财大四个Text
    public Text[] orderTexts; // 存储排序后的四个Text
    public float[] speeds; // 存储四个Cube的移动速度
    public float rotateSpeedMin; // 自转最小速度
    public float rotateSpeedMax; // 自转最大速度
    public float zPos; // 四个Cube的Z轴坐标

    private float[] positions; // 存储四个Cube的当前Z轴坐标
    private int[] order; // 存储排序后的四个Cube的索引

    // Start is called before the first frame update
    void Start()
    {
        positions = new float[4];
        order = new int[4];

        // 初始化四个Cube的位置和自转速度
        for (int i = 0; i < 4; i++)
        {
            transform.GetChild(i).position = new Vector3(0f, 0f, Random.Range(0f, 10f));
            speeds[i] = Random.Range(1f, 4f);
            transform.GetChild(i).GetComponent<Rigidbody>().angularVelocity = new Vector3(0f, 0f, Random.Range(rotateSpeedMin, rotateSpeedMax));
        }

        // 初始化四个Text的位置
        for (int i = 0; i < 4; i++)
        {
            infoTexts[i].transform.position = transform.GetChild(i).position + new Vector3(0f, 0f, -1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 移动四个Cube
        for (int i = 0; i < 4; i++)
        {
            positions[i] = transform.GetChild(i).position.z;
            transform.GetChild(i).Translate(new Vector3(0f, 0f, speeds[i] * Time.deltaTime));
        }

        // 更新四个Text的位置
        for (int i = 0; i < 4; i++)
        {
            infoTexts[i].transform.position = transform.GetChild(i).position + new Vector3(0f, 0f, -1f);
        }

        // 对四个Cube按Z轴坐标进行排序
        for (int i = 0; i < 4; i++)
        {
            order[i] = i;
        }
        for (int i = 0; i < 3; i++)
        {
            for (int j = i + 1; j < 4; j++)
            {
                if (positions[order[i]] < positions[order[j]])
                {
                    int temp = order[i];
                    order[i] = order[j];
                    order[j] = temp;
                }
            }
        }

        // 更新排序后的四个Text的位置和顺序
        for (int i = 0; i < 4; i++)
        {
            orderTexts[i].transform.position = new Vector3(0f, 0f, -1f * (i + 1));
            orderTexts[i].transform.SetAsLastSibling();
            orderTexts[i].text = infoTexts[order[i]].text;
        }
    }
}
