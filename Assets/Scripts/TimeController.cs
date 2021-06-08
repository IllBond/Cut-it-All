using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField] private MoveForward _speed;
    [SerializeField] private Camera _camera;


    private float _normalSpeed = 20;
    private float _slowSpeed = 0;
   


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("ObjectToBeCut"))
        {
            
            OnTouch();
            other.GetComponent<Rigidbody>().drag = 15f;


        }
    }      
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("ObjectToBeCut"))
        {

            IsEnemyDead();
 
        }
    }    
    


    private void OnTouch() {

        _speed.speed = _slowSpeed;

       // Time.timeScale = 0.5f;

    }    
    
    public void IsEnemyDead() {


        _speed.speed = _normalSpeed;
        //Time.timeScale = 1.0f;

    }


}
