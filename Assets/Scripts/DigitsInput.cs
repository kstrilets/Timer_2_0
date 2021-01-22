using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DigitsInput : MonoBehaviour
{
    [SerializeField] Text digitsText;
    [SerializeField] Text helperDigitsText;
    [SerializeField] GameObject addNewTimer;

    Queue<int> inputQueue = new Queue<int>();

    int[] d = new int[] { 0, 0, 0, 0 };
    int[] hms = new int[] { 0, 0, 0 };

    private void Start()
    {
        ResetQueue();
    }

    public void Input(int digit)
    {
        if (inputQueue.Count < 4)
        {
            inputQueue.Enqueue(digit);
        }
        else
        {
            inputQueue.Dequeue();
            inputQueue.Enqueue(digit);
        }

        HelperDigitsTextUpdate(inputQueue);
    }

    private void DigitTextUpdate()
    {
        digitsText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hms[0], hms[1], hms[2]);
    }

    void HelperDigitsTextUpdate(Queue<int> q)
    {
        d = q.ToArray();
        helperDigitsText.text = string.Format($"{ d[0]}{d[1]}{d[2]}{d[3]}");
    }
    
    int QueueInputToInt(Queue<int> _queue)
    {
        int returnInt = 0;
        int[] digits = _queue.ToArray();

        for (int i = 0; i < digits.Length; i++)
        {
            returnInt += digits[i] * (int)(1000 / Math.Pow(10, i));
        }

        return returnInt;
    }

    void HMSReset()
    {
        hms[0] = 0;
        hms[1] = 0;
        hms[2] = 0;
    }

    public void HoursPressed()
    {
        hms[0] = QueueInputToInt(inputQueue);
        if (hms[0] > 99) hms[0] = 99;
        ResetQueue();
        DigitTextUpdate();
    }

    public void MinutesPressed()
    {
        hms[1] = QueueInputToInt(inputQueue);

        if (hms[1] > 59)
        {
            hms[0] += (int)Mathf.Floor(hms[1] / 60);
            if (hms[0] > 99)
            {
                hms[0] = 99;
                hms[1] = 59;
                hms[2] = 59;
            }
            hms[1] %= 60;
        }

        ResetQueue();
        DigitTextUpdate();

    }

    public void SecondsPressed()
    {
        hms[2] = QueueInputToInt(inputQueue);

        if (hms[2] > 59)
        {
            hms[1] += (int)Mathf.Floor(hms[2] / 60);
            if (hms[1] > 59)
            {
                hms[0] += (int)Mathf.Floor(hms[1] / 60);
                if (hms[0] > 99)
                {
                    hms[0] = 99;
                    hms[1] = 59;
                    hms[2] = 59;
                }
                hms[1] %= 60;
            }
            hms[2] %= 60;

        }

       ResetQueue();
       DigitTextUpdate();
    }

    public void ResetQueue()
    {
        inputQueue.Clear();
        for (int i = 0; i < 4; i++)
        {
            inputQueue.Enqueue(0);
        }

        HelperDigitsTextUpdate(inputQueue);

    }

    public void ResetButtonPressed()
    {
        HMSReset();
        ResetQueue();
        DigitTextUpdate();

    }

    public void OnPlusClick()
    {
        if (TimerManager.Instance.newTimerPressed)
        {
            AddTimer();
        }
        if (TimerManager.Instance.restTimePressed)
        {
            AddRestTime();
        }
    }

    public void AddRestTime()
    {
        TimerManager.Instance.restTimePressed = false;
       
        TimerManager.Instance.AddRestTime(hms[0] * 3600 + hms[1] * 60 + hms[2]);

        HMSReset();
        ResetQueue();
        DigitTextUpdate();
        
    }
    
    public void AddTimer()
    {
        TimerManager.Instance.newTimerPressed = false;
        if (hms[0] == 0 && hms[1] == 0 && hms[2] == 0)
        {
            return;
        }
        TimerManager.Instance.userTimers.Add(hms[0] * 3600 + hms[1] * 60 + hms[2]);
        addNewTimer.GetComponent<AddNewTimer>().AddTimerButton(hms[0] * 3600 + hms[1] * 60 + hms[2]);
        TimerManager.Instance.SaveTimers();
        HMSReset();
        ResetQueue();
        DigitTextUpdate();
        
    }
}