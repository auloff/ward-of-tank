using UnityEngine;

public class BaseStats : MonoBehaviour
{
    [SerializeField]
    [Min(1)]
    private float _health = 1;
    public float Heatlh 
    {
        get => _health; 
    }

    [SerializeField]
    [Min(1)]
    private float _shield = 1;
    public float Shield
    {
        get => _shield;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage / _shield;
    }
}
