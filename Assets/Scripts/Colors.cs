using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colors : MonoBehaviour
{
    [SerializeField] List<ColorScheme> colorScheme = new List<ColorScheme>();

    [SerializeField] List<Button> darkButtonsList = new List<Button>();
    [SerializeField] List<Button> lightButtonsList = new List<Button>();

    [SerializeField] List<Text> mainTextList = new List<Text>();
    [SerializeField] List<Text> helperTextList = new List<Text>();


    [Header("Background")]
    [SerializeField] List<Image> backgrounds = new List<Image>();

    

    public void ApplyColors(int i)
    {
        foreach (var item in backgrounds)
        {
            item.color = colorScheme[i].background;
        }

        foreach (var item in mainTextList)
        {
            item.color = colorScheme[i].mainText;
        }
        foreach (var item in helperTextList)
        {
            item.color = colorScheme[i].helperText;
        }
        foreach (var item in darkButtonsList)
        {
            item.image.color = colorScheme[i].darkButtons;
        }
        foreach (var item in lightButtonsList)
        {
            item.image.color = colorScheme[i].lightButtons;
        }

    }
}