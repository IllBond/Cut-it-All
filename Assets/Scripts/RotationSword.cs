using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSword : MonoBehaviour
{
    public Transform center;
    public float Angle;
    public float LastAngle;
    public Vector3 newPos;

    public TrailRenderer trail;

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

        if (isTouch)
        {
            trail.emitting = true;
            transform.position = Vector3.Lerp(transform.position, new Vector3(Mathf.Clamp(transform.position.x + newPos.x / 80, -4, 4), Mathf.Clamp(transform.position.y + newPos.y / 80, -4, 8), transform.position.z), 100 * Time.deltaTime);
        }
        else {
            trail.emitting = false;
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
        rotation.z = Angle;
   
        transform.localEulerAngles = rotation;

    }




}


