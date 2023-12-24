using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image Fill;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    void Update()
    {
        if (SwitchBody.inGhost)
        {
            Fill.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else
        {
            Fill.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }
    }
}
