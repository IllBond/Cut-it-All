using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBigObject : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _distance ;

    [SerializeField] private GameObject[] objects;


    void Start()
    {
        

        for (int i = 1; i < 50; i++)
        {
            SetObject(_distance*i);
        }
    }


    

    private void SetObject(float _distance) {
        Instantiate(objects[Random.Range(0, objects.Length)],  new Vector3(0,0, _distance + _player.position.z), Quaternion.identity, transform);
      
    }
}
