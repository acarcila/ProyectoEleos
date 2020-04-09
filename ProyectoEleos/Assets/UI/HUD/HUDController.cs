using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUDController : MonoBehaviour
{
    public Slider sliderHealthBar;
    public Slider sliderEnergyBar;

    public StatsController statsController;

    private void Update()
    {
        setHealth(statsController.getHealth(), statsController.getMaxHealth());
        setEnergy(statsController.getEnergy(), statsController.getMaxEnergy());
    }

    public void setHealth(int health, int maxHealth)
    {
        sliderHealthBar.value = ((float)health / (float)maxHealth);
    }

    public void setEnergy(int energy, int maxEnergy)
    {
        sliderEnergyBar.value = ((float)energy / (float)maxEnergy);
    }

}
