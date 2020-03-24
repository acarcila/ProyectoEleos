using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController : MonoBehaviour
{
    private int health;
    private int maxHealth;
    private int energy;
    private int maxEnergy;

    public void setHealth(int health)
    {
        this.health = health;
    }

    public int getHealth()
    {
        return health;
    }

    public void setMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }

    public void setEnergy(int energy)
    {
        this.energy = energy;
    }

    public int getEnergy()
    {
        return energy;
    }

    public void setMaxEnergy(int maxEnergy)
    {
        this.maxEnergy = maxEnergy;
    }

    public int getMaxEnergy()
    {
        return maxEnergy;
    }

}
