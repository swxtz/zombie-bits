using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensiSlider : MonoBehaviour
{
    public GameObject slider;
    private Slider sensiSlider;
    void Start()
    {
        sensiSlider = slider.GetComponent<Slider>();
    }

    // Update is called once per frame
    //void OnValueChanged()
    //{
    //    Debug.Log(sensiSlider.value);
    //    PlayerCamera.sensi = sensiSlider.value;
    //}
}
