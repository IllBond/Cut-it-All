using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class Cut : MonoBehaviour
{
    private Health _health;
    private TimeController _timeController;

    [SerializeField] private TimeController _rimeController;


    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("ObjectToBeCut") && other.gameObject.GetComponent<Rigidbody>())
        {
            _health = other.transform.parent.GetComponent<Health>();

            if (_health.health > 0)
            {
                _health.Damage();

                if (_health.health <= 0)
                {
                    _rimeController.IsEnemyDead();
                }


                Material mat;
                GameObject kesobj;

                mat = other.GetComponent<MeshRenderer>().material;
                kesobj = other.gameObject;

                SlicedHull Kesilen = Kes(kesobj, mat);

                if (Kesilen == null) { return; }

                GameObject kesilenust = Kesilen.CreateUpperHull(kesobj, mat);
                kesilenust.AddComponent<BoxCollider>();
                kesilenust.AddComponent<Rigidbody>();
                //kesilenust.AddComponent<Health>();
                kesilenust.GetComponent<Rigidbody>().drag = 4;
               

                kesilenust.transform.SetParent(other.transform.parent, false);
                StartCoroutine(Flash(0.1f, kesilenust));

                GameObject kesilenalt = Kesilen.CreateLowerHull(kesobj, mat);
                kesilenalt.AddComponent<BoxCollider>();
                kesilenalt.AddComponent<Rigidbody>();
                //kesilenalt.AddComponent<Health>();
                kesilenalt.GetComponent<Rigidbody>().drag = 4;
               

                kesilenalt.transform.SetParent(other.transform.parent, false);
                StartCoroutine(Flash(0.1f, kesilenalt));

                kesobj.transform.position = new Vector3(200, 200, 200); //*

                if (_health.health <= 0)
                {
                    Transform transformParent = other.transform.parent.GetComponent<Transform>();
                    for (int i = 0; i < transformParent.childCount; i++)
                    {
                        if (transformParent.GetChild(i).gameObject.layer == LayerMask.NameToLayer("ObjectToBeCut")) {
                            transformParent.GetChild(i).GetComponent<Rigidbody>().drag = 0;
                            transformParent.GetChild(i).GetComponent<Rigidbody>().mass = 20;
                            transformParent.GetChild(i).gameObject.layer = LayerMask.NameToLayer(default);
                        }
                       
                        
                    }
                }


            }
            /*else {
            


                Material mat;
                GameObject kesobj;
                mat = other.GetComponent<MeshRenderer>().material;
                kesobj = other.gameObject;
                SlicedHull Kesilen = Kes(kesobj, mat);
                if (Kesilen == null) { return; }

                GameObject kesilenust = Kesilen.CreateUpperHull(kesobj, mat);
                kesilenust.AddComponent<BoxCollider>();
                kesilenust.AddComponent<Rigidbody>();
                kesilenust.AddComponent<Health>();
                kesilenust.GetComponent<Rigidbody>().drag = 2;
                kesilenust.transform.SetParent(other.transform.parent, false);
              

                GameObject kesilenalt = Kesilen.CreateLowerHull(kesobj, mat);
                kesilenalt.AddComponent<BoxCollider>();
                kesilenalt.AddComponent<Rigidbody>();
                kesilenalt.AddComponent<Health>();
                kesilenalt.GetComponent<Rigidbody>().drag = 2;
                kesilenalt.transform.SetParent(other.transform.parent, false);
              

                kesobj.transform.position = new Vector3(200, 200, 200); //*

                _rimeController.IsEnemyDead();
            }*/
    
            

           
            /*}*/


        }
    }

    IEnumerator Flash(float time, GameObject obj)
    {
        yield return new WaitForSeconds(time);
        obj.layer = LayerMask.NameToLayer("ObjectToBeCut");
    }

    public SlicedHull Kes(GameObject obj, Material crossSectionMaterial = null)
    {
        return obj.Slice(transform.position, transform.right, crossSectionMaterial);
    }


    /*    void Update()
        {


            if (*//*Input.GetMouseButtonDown(0) &&*//* kesobj != null) {




               *//*     SlicedHull Kesilen = Kes(kesobj, mat);

                    GameObject kesilenust = Kesilen.CreateUpperHull(kesobj, mat);
                    kesilenust.AddComponent<MeshCollider>().convex = true;
                    kesilenust.AddComponent<Rigidbody>();
                    kesilenust.layer = LayerMask.NameToLayer("ObjectToBeCut");

                    GameObject kesilenalt = Kesilen.CreateLowerHull(kesobj, mat);
                    kesilenalt.AddComponent<MeshCollider>().convex = true;
                    kesilenalt.AddComponent<Rigidbody>();
                    kesilenalt.layer = LayerMask.NameToLayer("ObjectToBeCut");

                    kesobj.transform.position = new Vector3(200, 200, 200);

                    mat = null; 
                    kesobj = null;*//*

                    //Destroy();



            }
        }*/


}





/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class Cut : MonoBehaviour
{
    private Material[] mat;
    private GameObject[] kesobj;

    private void OnTriggerEnter(Collider[] other)
    {

        for (int i = 0; i < other.Length; i++)
        {
            if (other[i].gameObject.layer == LayerMask.NameToLayer("ObjectToBeCut"))
            {
                //Debug.Log(other[i].name);
                mat[i] = other[i].GetComponent<MeshRenderer>().material;
                kesobj[i] = other[i].gameObject;
            }
        }

    }

    private void OnTriggerExit(Collider[] other)
    {
        for (int i = 0; i < kesobj.Length; i++)
        {
            mat[i] = null;
            kesobj[i] = null;
        }
    }

    void Update()
    {
        for (int i = 0; i < kesobj.Length; i++)
        {
            if (Input.GetMouseButtonDown(0) && kesobj != null)
            {
                Debug.Log("Разрезаем");
                SlicedHull Kesilen = Kes(kesobj[i], mat[i]);

                GameObject kesilenust = Kesilen.CreateUpperHull(kesobj[i], mat[i]);
                kesilenust.AddComponent<MeshCollider>().convex = true;
                kesilenust.AddComponent<Rigidbody>();
                kesilenust.layer = LayerMask.NameToLayer("ObjectToBeCut");

                GameObject kesilenalt = Kesilen.CreateLowerHull(kesobj[i], mat[i]);
                kesilenalt.AddComponent<MeshCollider>().convex = true;
                kesilenalt.AddComponent<Rigidbody>();
                kesilenalt.layer = LayerMask.NameToLayer("ObjectToBeCut");

                Destroy(kesobj[i]);

            }
        }
    }

    public SlicedHull Kes(GameObject obj, Material crossSectionMaterial = null)
    {
        return obj.Slice(transform.position, transform.right, crossSectionMaterial);
    }
}*/
