using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSword : MonoBehaviour
{
    public Transform center;
    public float Angle;
    public float LastAngle;
    public Vector3 newPos;

    public bool isTouch;


    public Vector3 oldPosition;
    public Vector3 deltaPosition;

    
    private void Start()
    {
        oldPosition = transform.position;
    }

    private void Update()
    {
        oldPosition = transform.position;

        if (isTouch) {  
            transform.position = Vector3.Lerp(transform.position, new Vector3(Mathf.Clamp(transform.position.x + newPos.x / 20, -7, 7), Mathf.Clamp(transform.position.y + newPos.y / 20, -8, 8), transform.position.z), 100 * Time.deltaTime);
        }

        deltaPosition = Vector3.Lerp(deltaPosition, oldPosition - transform.position, 25 * Time.deltaTime);
        
        if (deltaPosition.x !=0 && deltaPosition.y != 0) {

            
            Angle = Mathf.Round(Mathf.LerpAngle(Angle, Mathf.Atan2(deltaPosition.y, deltaPosition.x) * Mathf.Rad2Deg + 90, 100 *Time.deltaTime));
           
        }
       

        TrackTarget();
    }

    private void TrackTarget()
    {
        Vector3 rotation = transform.localEulerAngles;

        var deltaY = transform.position.x - center.position.x;
        var deltaX = transform.position.y - center.position.y;




        rotation.y = (5 * deltaY);
        rotation.x = -(5 * deltaX);
        // transform.localEulerAngles = rotation;

        //rotation.z = Angle;
        //rotation.z = Angle;
       

        rotation.z = Angle;
        Debug.Log(Angle);
        transform.localEulerAngles = rotation;
        //transform.localEulerAngles = rotation;
        //transform.localEulerAngles = Vector3.SlerpUnclamped(transform.localEulerAngles, rotation, Time.deltaTime * 10);
        // transform.localEulerAngles = Vector3.Slerp(transform.localEulerAngles, rotation, Time.deltaTime);

        /*rotation.x = 0;
        rotation.y = 0;
        transform.localEulerAngles = rotation;*/
        //transform.localEulerAngles = Vector3.Slerp(transform.localEulerAngles, rotation, 5 * Time.deltaTime);


        /*        rotation.z = Angle1;
                transform.localEulerAngles = rotation;*/
    }

    void OnGUI()
    {
        //GUI.TextField(new Rect(10, 90, 400, 20), "Куда свайпаем " + currentSwipe, 100);
        GUI.TextField(new Rect(10, 170, 400, 20), "Угол " + Angle, 100);
    }


}


