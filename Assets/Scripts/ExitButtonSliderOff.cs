using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButtonSliderOff : MonoBehaviour
{
    private void Start()
    {
        Button btn = GetComponent<Button>();

        btn.onClick.AddListener(UIManager.Instance.OnExitButtonHide);
    }
}
