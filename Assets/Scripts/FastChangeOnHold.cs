//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.Events;
//using UnityEngine.EventSystems;
//using System;

//public class FastChangeOnHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
//{
//    bool pointerDown;
//    float pointerDownTimer;

//    public float requiredHoldTimeSeconds;

//    public UnityEvent onHold;
//    public bool addTime;

//    TimeSpan ts;
//    int _restTime;
//    int speed = 1;

//    float startTime;
//    float holdTime;

//     void Start()
//    {
//        _restTime = TimerManager.Instance.restTime;   
//    }

//    public void OnPointerDown(PointerEventData eventData)
//    {
//        Debug.Log("i am clicked!");
//        pointerDown = true;
//        startTime = Time.time;
//        speed = Mathf.FloorToInt(startTime);
//        //if (eventData)
//        //{
//        //    _restTime += speed;
//        //    if (_restTime > 360059) _restTime = 360059;

//        //}
//        //else
//        //{
//        //    _restTime -= speed;
//        //    if (_restTime < 0) _restTime = 0;

//        //}
//    }

//    public void OnPointerUp(PointerEventData eventData)
//    {
//        holdTime = Time.time - startTime;
//        Debug.Log(holdTime);
//        Reset();
//        TimerManager.Instance.restTime = _restTime;
//    }

//    void Reset()
//    {
//        pointerDown = false;
//        pointerDownTimer = 0;
//        speed = 1;
//    }

//    public void ChangeTime(bool _addTime)
//    {

//        if (_addTime)
//        {
//            _restTime += speed;
//            if (_restTime > 360059) _restTime = 360059;

//        }
//        else
//        {
//            _restTime -= speed;
//            if (_restTime < 0) _restTime = 0;

//        }

//        ts = TimeSpan.FromSeconds(_restTime);

//        if (_restTime <= 59)
//        {
//            UIManager.Instance.restTimeText.text = string.Format(":{0:00}", ts.Seconds);
//        }
//        else if (_restTime > 59 && _restTime < 3600)
//        {
//            UIManager.Instance.restTimeText.text = string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
//        }
//        else if (_restTime >= 3600)
//        {
//            UIManager.Instance.restTimeText.text = string.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);

//        }
//    }

//    void Update()
//    {
//      //  Debug.Log("Button");
      
//      //if (Input.GetMouseButtonDown(0))
//      //  {
//      //      startTime = Time.time;
//      //  }
//      //if (Input.GetMouseButton(0))
//      //  {
//      //      holdTime = Time.time - startTime;
//      //      Debug.Log(holdTime);
//      //  }
//      //if(Input.GetMouseButtonUp(0))
//      //  {
//      //      holdTime = Time.time - startTime;
//      //      Debug.Log(holdTime);
//      //  }




//        //if (pointerDown)
//        //{
//        //    pointerDownTimer += Time.deltaTime;
//        //    if (pointerDownTimer >= requiredHoldTimeSeconds)
//        //    {
//        //        if (onHold != null) onHold.Invoke();
//        //        Reset();
//        //    }
//        //    if (pointerDownTimer > 1)
//        //    {
//        //        speed = 10;
//        //    } else if (pointerDownTimer > 60)
//        //    {
//        //        speed = 60;
//        //    } else if (pointerDownTimer > 600)
//        //    {
//        //        speed = 600;
//        //    } else if (pointerDownTimer > 3600)
//        //    {
//        //        speed = 3600;
//        //    }
            
//        //}
//    }
//}
