using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSword : MonoBehaviour
{


    public float mouseSens = 100f;

    public float xx { get; set; } //Здесь позиция мышки
    public float yy { get; set; } //Здесь позиция мышки
    
    private float _speedRotation = 120f; // Скорось разворота



    private void Update()
    {

     
            //tapCoor = Input.mousePosition;
            //tapCoor.z = 10;

            //MousePosition = _camera.ScreenToWorldPoint(tapCoor); // Обновленеи позиции мышки
            TrackTarget();

        
    }

    // Функция следит за курсором мышки и поворачивается относительно него
    private void TrackTarget()
    {
        float angle = 90 +  Mathf.Round((Mathf.Atan2(yy, xx) * Mathf.Rad2Deg) / 20)*20  ; // Угол корабля по отношению к мышке
        Debug.Log(angle); //90 ...180 ... Куда повернуть

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //float angle = Mathf.Round(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg); // Угол корабля по отношению к мышке

      /*  Quaternion newQuaternion = new Quaternion();
        newQuaternion.Set(0, 0, angle, 1);*/
        
        
        transform.localEulerAngles = new Vector3(0, 0, angle);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _speedRotation * Time.deltaTime);
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(xx, yy, angle), _speedRotation * Time.deltaTime);


        //Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward); // Новый угол  поворотка коробля 
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _speedRotation * Time.deltaTime);
    }

}


