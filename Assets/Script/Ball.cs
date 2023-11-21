using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 2f;
    private Rigidbody rb;
    private bool movingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(ChangeColor());
    }

    void Update()
    {
        if (transform.position.x >= 10f)
        {
            movingRight = false;
            StartCoroutine(ChangeColor());
        }
        else if (transform.position.x <= 0f)
        {
            movingRight = true;
            StartCoroutine(ChangeColor());
        }

        if (movingRight)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else
        {
            rb.velocity = new Vector3(-speed, 0, 0);
        }
    }

    IEnumerator ChangeColor()
    {
        Color[] colors = { Color.red, Color.yellow, Color.green, Color.blue, Color.magenta, Color.cyan, Color.white };
        int index = 0;
        while (true)
        {
            yield return new WaitForSeconds(1f);
            GetComponent<Renderer>().material.color = colors[index];
            index = (index + 1) % colors.Length;
        }
    }
}
