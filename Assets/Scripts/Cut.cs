using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class Cut : MonoBehaviour
{
    /*    [SerializeField] private Material mat;
        [SerializeField] private GameObject kesobj;*/

    /*    public List<Material> mat = new List<Material>() {};
        public List<GameObject> kesobj = new List<GameObject>() {};*/



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("ObjectToBeCut") && other.gameObject.GetComponent<Rigidbody>())
        {
            Debug.Log(other.name);

            Material mat;
            GameObject kesobj;

            mat = other.GetComponent<MeshRenderer>().material;
            kesobj = other.gameObject;

            SlicedHull Kesilen = Kes(kesobj, mat);

            if (Kesilen == null) {
                return;
            }

            GameObject kesilenust = Kesilen.CreateUpperHull(kesobj, mat);
            kesilenust.AddComponent<BoxCollider>();
            kesilenust.AddComponent<Rigidbody>();
            kesilenust.GetComponent<Rigidbody>().AddExplosionForce(25f, Vector3.right, 10f);
            StartCoroutine(Flash(0.5f, kesilenust));

            GameObject kesilenalt = Kesilen.CreateLowerHull(kesobj, mat);
            kesilenalt.AddComponent<BoxCollider>();
            kesilenalt.AddComponent<Rigidbody>();
            kesilenalt.GetComponent<Rigidbody>().AddExplosionForce(25f, Vector3.left, 10f);
            StartCoroutine(Flash(0.5f, kesilenalt));

            kesobj.transform.position = new Vector3(200, 200, 200); //*
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
