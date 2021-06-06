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


    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Confined;
    }


    void Update()
    {
        if (isTouch)
        {
            DeltaPosition();
        }
        else {
        /*    currentSwipe = Vector2.zero;

            sword.newPos = currentSwipe;*/
        }
    }

    private void DeltaPosition( )   
    {
        sword.newPos = currentSwipe;
     /*   if (currentSwipe.y != 0 && currentSwipe.x != 0) {
            Angle = Mathf.Atan2(currentSwipe.y, currentSwipe.x) * Mathf.Rad2Deg + 90;
            sword.Angle = Angle;
        }*/
        
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
