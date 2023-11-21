using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    private void Update()
    {
        float randomSpeed = Random.Range(1f, 4f);
        transform.position += Vector3.forward * speed * Time.deltaTime;
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
