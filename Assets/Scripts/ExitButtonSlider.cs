using UnityEngine;
using UnityEngine.UI;

public class ExitButtonSlider : MonoBehaviour
{
    private void Start()
    {
        Button btn = GetComponent<Button>();

        btn.onClick.AddListener(UIManager.Instance.OnExitButtonShow);
    }

}
