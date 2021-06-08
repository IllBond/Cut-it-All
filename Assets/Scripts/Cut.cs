using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using UnityEngine.UI;

public class Cut : MonoBehaviour
{
    private Health _health;

    [SerializeField] private TimeController _rimeController;

    public int coins = 0;
    public Text coinsText;
    public GameObject _coin;

    private Transform _objectsParent;
   


    void Start()
    {
        //coinsText = GameObject.FindGameObjectsWithTag("CoinText")[0].GetComponent<Text>();
        coinsText.text = "0";
        _objectsParent = GameObject.FindGameObjectsWithTag("ObjectToBeCut")[0].GetComponent<Transform>();
    }

    public void AddScore()
    {

        coins++;
        coinsText.text = "" + coins;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Coin"))
        {
            other.gameObject.layer = LayerMask.NameToLayer("Default");
            AddScore();
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("ObjectToBeCut") && other.gameObject.GetComponent<Rigidbody>())
        {
            _health = other.transform.parent.GetComponent<Health>();
            _health.Damage();

            int rnd = Random.Range(0, 10);

            if (rnd == 5 && other.tag != "Coin")
            {
                GameObject coin = Instantiate(_coin, other.transform.position + new Vector3(0, 0, 5), Quaternion.identity, _objectsParent);

                //coin.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);

  
                StartCoroutine(SetCollider(0.5f, coin));
            }

            Material mat;
            GameObject kesobj;

            mat = other.GetComponent<MeshRenderer>().material;
            kesobj = other.gameObject;

            SlicedHull Kesilen = Kes(kesobj, mat);

            if (Kesilen == null) { return; }

            GameObject kesilenust = Kesilen.CreateUpperHull(kesobj, mat);
            kesilenust.AddComponent<Rigidbody>();
            kesilenust.GetComponent<Rigidbody>().drag = 4;
            kesilenust.AddComponent<MeshCollider>();
            kesilenust.GetComponent<MeshCollider>().convex = true;
            // kesilenust.GetComponent<Rigidbody>().AddExplosionForce(5f, new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)), 200f);
            //kesilenust.GetComponent<Rigidbody>().isKinematic = true; //затычка что бы появилась физика
            kesilenust.GetComponent<Rigidbody>().isKinematic = false; //затычка что бы появилась физика
            kesilenust.transform.SetParent(other.transform.parent, false);


            GameObject kesilenalt = Kesilen.CreateLowerHull(kesobj, mat);
            kesilenalt.AddComponent<Rigidbody>();
            kesilenalt.GetComponent<Rigidbody>().drag = 4;
            kesilenalt.AddComponent<MeshCollider>();
            kesilenalt.GetComponent<MeshCollider>().convex = true;
            // kesilenalt.GetComponent<Rigidbody>().AddExplosionForce(5f, Vector3.down, 200f);
            // kesilenalt.GetComponent<Rigidbody>().isKinematic = true; //затычка что бы появилась физика
            kesilenalt.GetComponent<Rigidbody>().isKinematic = false; //затычка что бы появилась физика
            kesilenalt.transform.SetParent(other.transform.parent, false);


            if (_health.health > 0)
            {
                StartCoroutine(Flash(0.15f, kesilenust));
                StartCoroutine(Flash(0.15f, kesilenalt));
            }
            else
            {
                _rimeController.IsEnemyDead();
                Transform transformParent = other.transform.parent.GetComponent<Transform>();
                for (int i = 0; i < transformParent.childCount; i++)
                {

                    if (transformParent.GetChild(i).gameObject.tag != "Coin")
                    {

                        transformParent.GetChild(i).GetComponent<Rigidbody>().isKinematic = false; //затычка что бы появилась физика
                    }
                    transformParent.GetChild(i).GetComponent<Rigidbody>().drag = 0.01f;
                    transformParent.GetChild(i).GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-40, 40), Random.Range(10, 40), 100);
                    transformParent.GetChild(i).gameObject.layer = LayerMask.NameToLayer("NOT_ObjectToBeCut"); //*****
                }
            }

            Destroy(kesobj);
        }
    }

    IEnumerator Flash(float time, GameObject obj)
    {
        yield return new WaitForSeconds(time);
        obj.layer = LayerMask.NameToLayer("ObjectToBeCut");
    }

    IEnumerator SetCollider(float time, GameObject obj)
    {
        yield return new WaitForSeconds(time);
        obj.gameObject.layer = LayerMask.NameToLayer("Coin"); //*****
        obj.gameObject.transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("ObjectToBeCut"); //*****

    }

    public SlicedHull Kes(GameObject obj, Material crossSectionMaterial = null)
    {
        return obj.Slice(transform.position, transform.right, crossSectionMaterial);
    }


}




