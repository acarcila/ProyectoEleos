using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private int energy;
    [SerializeField] private int maxEnergy;
    [SerializeField] private int damage;
    private float tiempo; // borrar después

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

    public void increaseHealth(int increaseValue)
    {
        if (health >= 0 && health <= maxHealth)
        {
            health += increaseValue;
        }

        if (health >= maxHealth)
        {
            health = maxHealth;
        }
    }

    public void decreaseHealth(int decreaseValue)
    {
        if (health > 0)
        {
            health -= decreaseValue;
        }

        if (health <= 0)
        {
            die();
        }
    }

    public void increaseEnergy(int increaseValue)
    {
        if (energy >= 0 && energy <= maxEnergy)
        {
            energy += increaseValue;
        }

        if (energy > maxEnergy)
        {
            energy = maxEnergy;
        }
    }

    public void decreaseEnergy(int decreaseValue)
    {
        if (energy > 0)
        {
            energy -= decreaseValue;
        }
        if (energy <= 0)
        {
            energy = 0;
            Debug.Log("sin energía");
        }
    }

    public void increaseDamage(int increaseValue)
    {
        damage += increaseValue;
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
