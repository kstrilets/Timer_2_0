
using UnityEngine;
using UnityEngine.UI;


public class ScreenSliderStartTimer : MonoBehaviour
{
    

    private void Start()
    {
        Button btn = GetComponent<Button>();
        
        btn.onClick.AddListener(UIManager.Instance.OnTimerStarted);
    }


}
