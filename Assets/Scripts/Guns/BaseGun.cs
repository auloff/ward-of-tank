using UnityEngine;

public abstract class BaseGun : MonoBehaviour
{
    [SerializeField]
    private float _delay;
    public float delay
    {
        get => _delay;
        set
        {
            if (value < 0f) _delay = 0f;
            else _delay = value;
        }
    }
    public abstract void Shoot();
    public abstract void TurnOn();
    public abstract void TurnOff();
}