using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSlideAddRestTimer : MonoBehaviour
{
    private void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(UIManager.Instance.OnAddRestTime);
        btn.onClick.AddListener(() => TimerManager.Instance.restTimePressed = true);
    }
}
