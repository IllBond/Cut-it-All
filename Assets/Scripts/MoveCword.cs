using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCword : MonoBehaviour
{
    public float mouseSens = 100f;
    public float xRotation = 0f;
    public float yRotation = 0f;
    public Transform PlayerBody;
    [SerializeField] private RotationSword sword;

    public Vector2 direction;

    private void Start()
    {
        //SwordController.SwipeEvent += SetCoor;
    }

    private void SetCoor() {
        Debug.Log("1");
    }

    void Update()
    {
        if (Input.GetMouseButton(0)) {
            float MouseX = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
            float MouseY = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;

            if (MouseX != 0 && MouseY != 0) {
                sword.direction = new Vector2(MouseX, MouseY);
                sword.xx = xRotation;
                sword.yy = yRotation;
            }

            direction = new Vector2(MouseY,MouseX);

            xRotation -= MouseX;
            xRotation = Mathf.Clamp(xRotation, -70, 70);

            yRotation += MouseY;
            yRotation = Mathf.Clamp(yRotation, -45, 45);

            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 90f);
            PlayerBody.Rotate(new Vector3(transform.position.x * xRotation, transform.position.y, transform.position.y));

            
        }

       
    }


}
