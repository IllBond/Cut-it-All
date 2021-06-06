using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField] private MoveForward _speed;
    [SerializeField] private Camera _camera;


    private float _normalSpeed = 15;
    private float _slowSpeed = 2;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("ObjectToBeCut"))
        {
            
            OnTouch();
 
        }
    }    
    


    private void OnTouch() {
    
            Debug.Log("Достронулся");
            _speed.speed = _slowSpeed;

    }    
    
    public void IsEnemyDead() {
    
            Debug.Log("Поехали");
            _speed.speed = _normalSpeed;

    }


}
