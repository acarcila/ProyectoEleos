using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController : MonoBehaviour
{
    private int health;
    private int maxHealth;
    private int energy;
    private int maxEnergy;
    private int damage;
    private float tiempo;

    private void Start()
    {
        health = 50;
        maxHealth = 100;
        energy = 50;
        maxEnergy = 100;
        damage = 50;
    }

    // probar los métodos, solo cambiar el nombre del metodo, cada 5 seg se llama el metodo
    private void Update()
    {

        tiempo += Time.deltaTime;

        if (tiempo >= 4f)
        {
            decreaseDamage(5);
            Debug.Log(damage);
            tiempo = 0;
        }
    }

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

    public void setDamage(int damage)
    {
        this.damage = damage;
    }

    public int getDamage()
    {
        return damage;
    }

    public void increaseHealth(int valueIncrease)
    {
        if (health >= 0 && health <= maxHealth)
        {
            health += valueIncrease;
        }

        if (health >= maxHealth)
        {
            health = maxHealth;
        }
    }

    public void decreaseHealth(int valueDecrease)
    {
        if (health > 0)
        {
            health -= valueDecrease;
        }

        if (health <= 0)
        {
            die();
        }
    }

    public void increaseEnergy(int valueIncrease)
    {
        if (energy >= 0 && energy <= maxEnergy)
        {
            energy += valueIncrease;
        }

        if (energy > maxEnergy)
        {
            energy = maxEnergy;
        }
    }

    public void decreaseEnergy(int valueDecrease)
    {
        if (energy > 0)
        {
            energy -= valueDecrease;
        }
        if (energy <= 0)
        {
            Debug.Log("sin energía");
        }
    }

    public void increaseDamage(int valueIncrease)
    {
        damage += valueIncrease;
    }

    public void decreaseDamage(int valueDecrease)
    {
        if (damage > 0)
        {
            damage -= valueDecrease;
        }
    }

    public void die()
    {
        Debug.Log("Mori");
    }
}
