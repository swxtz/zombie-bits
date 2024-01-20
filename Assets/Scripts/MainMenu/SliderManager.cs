using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{

    [Header("Objects")]
    [SerializeField] private TMP_Text label;
    [SerializeField] private TMP_Text sliderValueLabel;
    [SerializeField] private Slider slider;

    [Header("Helpers")]
    [SerializeField] private string labelText;
    [SerializeField] private float maxSliderRange = 0f;
    [SerializeField] private float minSliderRange = 100f;
    [SerializeField] private string saveKey;

    private MainMenuManager mainMenuManager;
    private float sliderValue;


    private void Start()
    {
        label.text = labelText;
        slider.maxValue = maxSliderRange;
        slider.minValue = minSliderRange;

        slider.onValueChanged.AddListener((value) =>
        {
            sliderValue = value;
            sliderValueLabel.text = value.ToString("0.00");
        });

        sliderValueLabel.text = sliderValue.ToString("0.00");
    }

}
