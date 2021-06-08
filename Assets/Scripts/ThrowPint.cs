using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPint : MonoBehaviour
{

    // Проверка в коробке ли рука?
    [SerializeField] private ThrowObject _enemy;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("BoxWithObjects"))
        {
            _enemy.SetObject();
        }
    }
}
