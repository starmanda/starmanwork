using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        Color[] colors = { Color.red, Color.yellow, Color.green, Color.blue, Color.magenta, Color.cyan, Color.white };
        int index = 0;
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            GetComponent<Renderer>().material.color = colors[index];
            index = (index + 1) % colors.Length;
        }
    }

    void OnTriggerExit(Collider other)
    {
        StopCoroutine(ChangeColor());
    }
}
