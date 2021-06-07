using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 20;

    void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(0f, 0f, Time.deltaTime * speed);
    }
}
