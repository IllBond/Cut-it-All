using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveSword : MonoBehaviour
{

    public bool isTouch;

    public bool isStpedSwipe;

    public Vector3 xPosition;
    public Vector3 yPosition;

    public float Angle = 0f;

    public Transform PlayerBody;
    [SerializeField] private RotationSword sword;

    Vector2 currentSwipe;


    public AudioSource Audio_A;
    public AudioClip swipe_audio;

    public void CutAudio()
    {
        PlayMusic(swipe_audio);
    }

    public void PlayMusic(AudioClip music)
    {
        Debug.Log("Звук");
        Audio_A.PlayOneShot(music);
    }

    void Update()
    {
        if (isTouch)
        {
            DeltaPosition();
        }
        
  
    }

    private void DeltaPosition( )   
    {

        Debug.Log(currentSwipe);
        Debug.Log(isStpedSwipe);

        if (currentSwipe.x == 0 && currentSwipe.y == 0) {
            isStpedSwipe = false;
        }


        if (!isStpedSwipe) {
            if (Mathf.Abs(currentSwipe.x) > 20 || Mathf.Abs(currentSwipe.y) > 20)
            {
                CutAudio();
                isStpedSwipe = true;
            }
        }
       

        sword.newPos = currentSwipe;


    }



    public void OnFindDelta(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        currentSwipe = value;
    }



    public void OnTouch(InputAction.CallbackContext context)
    {
        bool started = context.started;
        bool canseled = context.canceled;

        if (started)
        {
            isTouch = true;
            sword.isTouch = true;
        }

        if (canseled)
        {
            isTouch = false;
            sword.isTouch = false;
        }
    }
}
