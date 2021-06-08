using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Range(1, 6)] public  int  health; 
    //public GameObject healthObject;


    public void Damage() {
        health--;
    }

/*    public void DrawHealth() {

        if (health == 1)
        {
            Instantiate(healthObject, transform.position + new Vector3(0 * 20, 0.04f * 20 + 2, 0), Quaternion.identity, transform);
        }
        else if (health == 2)
        {
            Instantiate(healthObject, transform.position + new Vector3(-0.025f * 20, 0.04f * 20 + 2, 0), Quaternion.identity, transform);
            Instantiate(healthObject, transform.position + new Vector3(0.025f * 20, 0.04f * 20 + 2, 0), Quaternion.identity, transform);
        }
        else
        {
            Instantiate(healthObject, transform.position + new Vector3(-0.05f * 20, 0.04f * 20 + 2, 0), Quaternion.identity, transform);
            Instantiate(healthObject, transform.position + new Vector3(0f * 20, 0.04f * 20 + 2, 0), Quaternion.identity, transform);
            Instantiate(healthObject, transform.position + new Vector3(0.05f * 20, 0.04f * 20 + 2, 0), Quaternion.identity, transform);
        }
    }*/
}
