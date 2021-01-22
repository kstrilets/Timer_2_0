
using UnityEngine;
using UnityEngine.UI;

public class ScreenSliderBackToMain : MonoBehaviour
{
    private void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(UIManager.Instance.OnTimerFinished);
    }

}
