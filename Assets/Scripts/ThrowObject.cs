using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{

    [SerializeField] private float delay;
    [SerializeField] private GameObject _mainPoint;
   // [SerializeField] private GameObject _coin;
    /*[SerializeField] */private Transform _objectsParent;
    [SerializeField] private GameObject[] objects;
   /* [SerializeField]*/ private Transform _hero;

    void Start()
    {
        StartCoroutine(StartAnim(delay));

        _objectsParent = GameObject.FindGameObjectsWithTag("ObjectToBeCut")[0].GetComponent<Transform>();
        _hero = GameObject.FindGameObjectsWithTag("PointTarget")[0].GetComponent<Transform>();

    }


    // Запускается с задержкой 
    IEnumerator StartAnim(float time)
    {
        yield return new WaitForSeconds(time);
        GetComponent<Animator>().enabled = true;
    }



    // Когда рука в коробке функция вызовиться. Создасться предмет и через 1,6 сек он будет брошен
    [ContextMenu("SetObject")]
    public  void SetObject() {
        if (objects.Length > 0) {
            var obj = Instantiate(objects[Random.Range(0, objects.Length)], _mainPoint.GetComponent<Transform>().position, Quaternion.identity, _objectsParent);
            obj.transform.parent = _mainPoint.transform.parent;
            StartCoroutine(OnThrowObject(obj, 1.6f));
        }
    }


    // Обьект брошен мы меняем ему родителя
    IEnumerator OnThrowObject(GameObject obj,float time) {
        yield return new WaitForSeconds(time);

        var objRB = obj.GetComponent<Transform>().GetChild(0).GetComponent<Rigidbody>();
        objRB.isKinematic = false;
        objRB.drag = 0;

        objRB.AddForce(new Vector3(_hero.transform.position.x - obj.transform.position.x, _hero.transform.position.y - obj.transform.position.y, _hero.transform.position.z - obj.transform.position.z)/2, ForceMode.Impulse);
        obj.transform.parent = _objectsParent;
    }    
    



}
