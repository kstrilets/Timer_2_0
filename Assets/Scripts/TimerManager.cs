using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class TimerManager : MonoBehaviour
{
    private static TimerManager _instance;

    public static TimerManager Instance
        
    {
        get { return _instance; }
    }

    Timer timer;
    //public int restTime = 0;
    public HashSet<int> userTimers = new HashSet<int>();
    [HideInInspector]
    public bool newTimerPressed = false;
    [HideInInspector]
    public bool restTimePressed = false;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {     
        timer = GetComponent<Timer>();
    }

    public void AddStartTimers()
    {
        userTimers.Add(30);
        userTimers.Add(60);
        userTimers.Add(90);
        userTimers.Add(120);

        LoadTimers();
    }

    public void AddRestTime(int _seconds)
    {
        timer.OnRestTime(_seconds);
    }

    public void StartTimer(float s)
    {
        timer.StartTimer(s);
    }

    public void StopTimer()
    {
        timer.StopTimer();
    }

    Save CreateSavedUserTimers()
    {
        Save save = new Save();

        if (userTimers != null)
        {
            save.savedUserTimers.Clear();
            foreach (var item in userTimers)
            {
                save.savedUserTimers.Add(item);
            }
        }
        return save;
    }

    public void SaveTimers()
    {
        Save save = CreateSavedUserTimers();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/usersave.save");
        bf.Serialize(file, save);
        file.Close();
    }

    public void LoadTimers()
    {
        if(File.Exists(Application.persistentDataPath + "/usersave.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/usersave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            if (save.savedUserTimers != null)
            {
                userTimers.Clear();
                foreach (int item in save.savedUserTimers)
                {
                    userTimers.Add(item);
                }
                save.savedUserTimers.Clear();
            }
            
        }else
        {
            Debug.Log("No save file!");
        }
    }

    public void ExitApp()
    {
        Screen.sleepTimeout = SleepTimeout.SystemSetting;
        Application.Quit();
    }
}