using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveSword : MonoBehaviour
{

    public bool isTouch;

    public Vector3 xPosition;
    public Vector3 yPosition;

    public float Angle = 0f;

    public Transform PlayerBody;
    [SerializeField] private RotationSword sword;

    Vector2 currentSwipe;


    void Update()
    {
        if (isTouch)
        {
            DeltaPosition();
        }
  
    }

    private void DeltaPosition( )   
    {
        sword.newPos = currentSwipe;
    }



    public void OnFindDelta(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        currentSwipe = value;
    }



    public void OnTouch(InputAction.CallbackContext context)
    {
        bool started = context.started;
        bool canseled = context.canceled;

        if (started)
        {
            isTouch = true;
            sword.isTouch = true;
        }

        if (canseled)
        {
            isTouch = false;
            sword.isTouch = false;
        }
    }
}
