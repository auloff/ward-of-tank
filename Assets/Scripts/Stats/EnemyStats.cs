using UnityEngine;

public class EnemyStats : BaseStats
{
    [Min(1)]
    [SerializeField]
    private float _damage = 1;
    public float damage
    {
        get => _damage;
        set
        {
            if (value <= 0) _damage = 1;
            else _damage = value;
        }
    }
}
