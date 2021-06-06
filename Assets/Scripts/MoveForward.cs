using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 dir;
    public float speed = 20;



    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(0f, 0f, Time.deltaTime * speed);
    }
}
