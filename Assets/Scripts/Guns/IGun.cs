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
            if (_delay < 0) _delay = 0;
            else _delay = value;
        }
    }
    public abstract void Shoot();
    public abstract void TurnOn();
    public abstract void TurnOff();
}