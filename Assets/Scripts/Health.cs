using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health; //1-3

    public GameObject healthObject;

    public void Start()
    {
        if (health == 1)
        {
            Instantiate(healthObject, transform.position + new Vector3(0 * 20, 0.04f * 20 + 2,  0), Quaternion.identity, transform);
        }
        else if (health == 2) {
            Instantiate(healthObject, transform.position + new Vector3(-0.025f * 20, 0.04f * 20+ 2,  0), Quaternion.identity, transform);
            Instantiate(healthObject, transform.position + new Vector3(0.025f * 20, 0.04f * 20 +2,  0), Quaternion.identity, transform);
        }
        else
        {
            Instantiate(healthObject, transform.position + new Vector3(-0.05f*20 , 0.04f * 20+2,  0), Quaternion.identity, transform);
            Instantiate(healthObject, transform.position + new Vector3(0f * 20, 0.04f * 20 + 2,  0), Quaternion.identity, transform);
            Instantiate(healthObject, transform.position + new Vector3(0.05f * 20, 0.04f * 20 + 2, 0), Quaternion.identity, transform);
        }
    }
    public void Damage() {
        transform.GetChild(health).GetComponent<DestroyHealth>().DestroyThis();
        health--;
        
        Debug.Log("Жизней " + health);
        if (health == 0) {
            Debug.Log("Мертв");
        }
    }
    
}
