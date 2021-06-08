using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPint : MonoBehaviour
{
    [SerializeField] private ThrowObject _enemy;



    private void OnTriggerEnter(Collider other)
    {

        

            if (other.gameObject.layer == LayerMask.NameToLayer("BoxWithObjects"))
            {
                _enemy.SetObject();
                
          
        }
    }
}
