using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class TimerEvent: UnityEvent<float>
{
}

public class StartCustomTimer : MonoBehaviour
{
    public TimerEvent myTimerEvent;
    Text thisTimerText;
    int seconds;

    void Start()
    {
        if (myTimerEvent == null) myTimerEvent = new TimerEvent();
        myTimerEvent.AddListener((seconds) => TimerManager.Instance.StartTimer(seconds));
        thisTimerText = gameObject.GetComponentInChildren<Text>();
    }

    public void OnEvent()
    {

        //var parts = thisTimerText.text.Split(':');


        //if (parts.Length == 3)
        //{
        //    seconds = short.Parse(parts[0]) * 3600 + short.Parse(parts[1]) * 60 + short.Parse(parts[2]);
        //}
        //else if (parts.Length == 2 && parts[0] == "")
        //{
        //    seconds = short.Parse(parts[1]);
        //}
        //else if (parts.Length == 2)
        //{
        //    seconds = short.Parse(parts[0]) * 60 + short.Parse(parts[1]);
        //}

        int seconds = Utils.HelperParseToInt(thisTimerText.text);

        myTimerEvent.Invoke(seconds);
    }
}