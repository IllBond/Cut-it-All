using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSword : MonoBehaviour
{
    public Vector2 direction { get;  set; } //Здесь позиция мышки
 
    public float xx { get; set; } //Здесь позиция мышки
    public float yy { get; set; } //Здесь позиция мышки
    /*  public Vector3 tapCoor;*/
    
    private float _speedRotation = 120f; // Скорось разворота

   //public Camera _camera; // Здесь находится камера

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
        float angle = Mathf.Round(Mathf.Atan2(yy, xx) * Mathf.Rad2Deg) ; // Угол корабля по отношению к мышке
        Debug.Log(angle); //90 ...180 ... Куда повернуть
        /*  Debug.Log(xx); //90 ...180 ... Куда повернуть
          Debug.Log(yy); //90 ...180 ... Куда повернуть*/



        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //float angle = Mathf.Round(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg); // Угол корабля по отношению к мышке

        /*  Quaternion newQuaternion = new Quaternion();
          newQuaternion.Set(0, 0, angle, 1);
 */
        
        //transform.localEulerAngles = new Vector3(0, 0, angle + 90);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _speedRotation * Time.deltaTime);
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(xx, yy, angle), _speedRotation * Time.deltaTime);


         //Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward); // Новый угол  поворотка коробля 
         transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _speedRotation * Time.deltaTime);
    }

}


