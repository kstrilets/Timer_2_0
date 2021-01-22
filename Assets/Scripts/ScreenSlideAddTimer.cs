using UnityEngine;
using UnityEngine.UI;

public class ScreenSlideAddTimer : MonoBehaviour
{
    private void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(UIManager.Instance.OnAddTimer);
        btn.onClick.AddListener(() => TimerManager.Instance.newTimerPressed = true);
       
    }
}