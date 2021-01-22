using UnityEngine;

[CreateAssetMenu(menuName = "ColorScheme")]
public class ColorScheme: ScriptableObject
{
    [Header("Background")]
    public Color background;

    [Header("Buttons")]
    public Color darkButtons;
    public Color lightButtons;

    //public Color exitButton;
    //public Color restTimeButton;
    //public Color repeatIconButton;
    //public Color plusButton;
    //public Color minusButton;
    //public Color timerPresetButton;
    //public Color stopButton;
    //public Color addTimerButton;
    //public Color saveTimerButton;

    [Header("Text")]
    public Color mainText;
    public Color helperText;
    //public Color restTimeText;
    //public Color repeatTimeText;
    //public Color timerPresetText;
    //public Color timerText;
    //public Color timerHelperText;
    //public Color HMSButtonsText;
    //public Color digitButtonText;
    //public Color clearButtonText;
    //public Color digitHelperText;
   
}