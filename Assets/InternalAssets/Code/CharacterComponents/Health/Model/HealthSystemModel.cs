using System;

[Serializable]
public struct HealthSystemModel : IHealthSystemModel
{
    private int maxHealth;
    private int health;

    public int MaxHealth => maxHealth;

    public int Health => health;

    public HealthSystemModel(int maxHealth)
    {
        this.maxHealth = maxHealth;
        health = maxHealth;
    }

    public void SetHealth(int health) 
    {
        this.health = health;
    }
}
