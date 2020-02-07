using System;
using UnityEngine;

public class BaseStats : MonoBehaviour
{
    public event Action HealthChanged;
    public event Action ShieldChanged;

    [SerializeField]
    [Min(1)]
    private float _health = 1;
    public float heatlh 
    {
        get => _health;
    }

    [SerializeField]
    [Range(1, 10)]
    private float _shield = 1;
    public float shield
    {
        get => _shield;
        set
        {
            if (value <= 0) _shield = 1;
            else if (value >= 11) _shield = 10;
            else _shield = value;
            ShieldChanged?.Invoke();
        }
    }

    public void TakeDamage(float damage)
    {
        if (damage <= 0) return;

        _health -= damage / _shield;
        HealthChanged?.Invoke();
    }

    public void TakeHealth(float health)
    {
        if (health <= 0) return;

        _health += health;
        HealthChanged?.Invoke();
    }
}