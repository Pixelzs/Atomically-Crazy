using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Slider plasmaSlider;

    // Health Slider
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    //Plasma Slider
    public void SetMaxPlasma(int plasma, int startingplasma)
    {
        plasmaSlider.maxValue = plasma;
        plasmaSlider.value = startingplasma;

    }
    public void SetPlasma(int plasma)
    {
        plasmaSlider.value = plasma;
    }
}
