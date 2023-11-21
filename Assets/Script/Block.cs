using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float xPosition;
    public Rigidbody rigidbody;
    public Collider collider;
    public Trigger trigger;

    private void Start()
    {
        rigidbody.velocity = new Vector3(xPosition, 0, 0);
    }
}
