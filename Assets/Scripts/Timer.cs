using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;           //alarm sound
    
    [SerializeField] Text timerAuxText;

    Color tmpColor;

    //public Canvas timerDigitsCanvas;
    //public Canvas numberOfTimersCanvas;
    //public Canvas restTimeCanvas;
    //public Canvas selectTimeCanvas;

    [SerializeField] Text numberOfTimersText;
    [SerializeField] Text restTimeText;
    [SerializeField] Text restTimeMainScreenText;

    [SerializeField] Text timerText;
    int numberOfTimers = 1;
    int restTime = 0;

    TimeSpan ts;
   
    public void OnNumberOfTimers(bool addTimer)
    {
        _ = addTimer ? numberOfTimers++ : numberOfTimers--;

        if (numberOfTimers > 99) numberOfTimers = 99;
        else if (numberOfTimers < 1) numberOfTimers = 1;

        numberOfTimersText.text = numberOfTimers.ToString();
    }

    public void OnRestTime(int _seconds)
    {
        restTime = _seconds;

        ts = TimeSpan.FromSeconds(_seconds);

        if (_seconds <= 59)
        {
            restTimeText.text = string.Format(":{0:00}", ts.Seconds);
            restTimeMainScreenText.text = string.Format(":{0:00}", ts.Seconds);

        }
        else if (_seconds > 59 && _seconds < 3600)
        {
            restTimeText.text = string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
            restTimeMainScreenText.text = string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);

        }
        else if (_seconds >= 3600)
        {
            restTimeText.text = string.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
            restTimeMainScreenText.text = string.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
        }
    }

    public void StartTimer (float sec)                  
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        StopAllCoroutines();
        timerText.text = "0:00";

        StartCoroutine("TimerText", sec);
    }

    public void StopTimer()
    {
        StopAllCoroutines();
    }

    IEnumerator TimerText(int s)
    {
        int _inputSeconds = s;                        
        bool sound = true;
        int tmpRestTime;
        
        for (int timers = 0; timers < numberOfTimers; timers++)
        {
           
            while (_inputSeconds > -1)
            {
                timerText.text = Utils.HelperParseToString(_inputSeconds);
                timerAuxText.text = "TIMER " + (timers + 1) + "/" + numberOfTimers;
                yield return new WaitForSecondsRealtime(1);
                _inputSeconds--;                            //counting down

                if (_inputSeconds <= 1 && sound)
                {
                    StartCoroutine(PlayAlarmSound());       //playing sound 1 sec before timer goes to 
                    Handheld.Vibrate();                     //zero, so sound comes first :)
                    sound = false;                          //preventing sound to play again
                }

                if (_inputSeconds < 0 && restTime > 0 && ((numberOfTimers - timers) > 1))
                { 
                    tmpColor = timerText.color;
                    tmpRestTime = restTime;

                    RestTimerBlinking();
                }
            }
            _inputSeconds = s;
            sound = true;
        }

        IEnumerator RestTimerBlinking()
        {
            for (int i = 0; i <= restTime; i++)
            {
                timerText.color = new Color(0, 0, 0, 0);
                timerText.text = Utils.HelperParseToString(tmpRestTime);
                timerAuxText.text = "REST";
                yield return new WaitForSecondsRealtime(0.5f);

                timerText.color = tmpColor;
                yield return new WaitForSecondsRealtime(0.5f);

                tmpRestTime--;
            }
        }
    }

    IEnumerator PlayAlarmSound()
    {
        audioSource.Play(0);
        yield return new WaitForSecondsRealtime(5f);
        audioSource.Stop();
    }
}