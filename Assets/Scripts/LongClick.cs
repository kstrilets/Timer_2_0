using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

public class LongClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool pointerDown;
    float pointerDownTimer;

    public float requiredHoldTime;

    public UnityEvent onLongClick;


    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
    }

    void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
    }

    public void DeleteTimer()
    {
        int seconds = Utils.HelperParseToInt(gameObject.transform.GetChild(0).GetComponent<Text>().text);
        Handheld.Vibrate();
        TimerManager.Instance.userTimers.Remove(seconds);
        TimerManager.Instance.SaveTimers();
        Destroy(gameObject);
    }

    void Update()
    {
        if(pointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer >= requiredHoldTime)
            {
                if (onLongClick != null) onLongClick.Invoke();
                Reset();
            }
           
        }
    }
}