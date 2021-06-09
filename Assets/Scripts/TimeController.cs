using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField] private MoveForward _speed;
    [SerializeField] private Camera _camera;


    private float _normalSpeed = 20;
    private float _slowSpeed = 0;


    private float cameraOriginalPos ;
    private float cameraNewPos;
    private bool isNeedZoom;


    private void Start()
    {
        cameraOriginalPos = _camera.fieldOfView;
    }


    private void Update()
    {
        if (isNeedZoom) {
            _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, cameraNewPos, Time.deltaTime);
            if (Mathf.Abs(_camera.fieldOfView - cameraNewPos) < 1) {
                Debug.Log("Пришли к " + cameraNewPos);
                isNeedZoom = false;
            }
        }
        
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("ObjectToBeCut"))
        {
            OnTouch();
            other.GetComponent<Rigidbody>().drag = 15f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("ObjectToBeCut"))
        {
            IsEnemyDead();
        }
    }

    private void OnTouch()
    {
       
        StartCoroutine(FlashPlus(0.25f));
    }

    public void IsEnemyDead()
    {

        StartCoroutine(FlashMinus(0.25f));
      
    }

    IEnumerator FlashPlus(float time)
    {
        yield return new WaitForSeconds(time);
        _speed.speed = _slowSpeed;
        Time.timeScale = 0.3f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        cameraNewPos = 26;
        isNeedZoom = true;
    }

    IEnumerator FlashMinus(float time)
    {
        yield return new WaitForSeconds(time);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        isNeedZoom = true;
        _speed.speed = _normalSpeed;
        cameraNewPos = cameraOriginalPos+1;
    }
}
